using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ViraRankApi.Data;
using ViraRankApi.Helpers;
using ViraRankApi.Models;

namespace ViraRankApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ViraRankContext _db;
        private readonly IConfiguration _config;

        public AuthController(ViraRankContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (await _db.Users.AnyAsync(u => u.Email == dto.Email))
                return BadRequest(new { message = "Email already in use" });
            if (await _db.Users.AnyAsync(u => u.UserName == dto.UserName))
                return BadRequest(new { message = "UserName already in use" });

            PasswordHelper.CreatePasswordHash(dto.Password, out var salt, out var hash);

            var user = new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                BirthDate = dto.BirthDate,
                Gender = dto.Gender,
                PasswordHash = hash,
                PasswordSalt = salt
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            var token = GenerateJwtToken(user);
            return Ok(new { token });
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _db.Users.SingleOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null || user.PasswordSalt == null || user.PasswordHash == null)
                return Unauthorized();

            var ok = PasswordHelper.VerifyPassword(dto.Password, user.PasswordSalt, user.PasswordHash);
            if (!ok) return Unauthorized();

            var token = GenerateJwtToken(user);
            return Ok(new { token });
        }

        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> Me()
        {
            var idClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (idClaim == null) return Unauthorized();

            if (!int.TryParse(idClaim, out var id)) return Unauthorized();

            var user = await _db.Users.AsNoTracking()
                .Where(u => u.Id == id)
                .Select(u => new { u.Id, u.UserName, u.Email, u.BirthDate, u.Gender })
                .SingleOrDefaultAsync();

            return Ok(user);
        }

        private string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(int.Parse(_config["Jwt:ExpiresMinutes"] ?? "60")),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    public record RegisterDto(string UserName, string Email, DateTime BirthDate, bool Gender, string Password);
    public record LoginDto(string Email, string Password);
}
