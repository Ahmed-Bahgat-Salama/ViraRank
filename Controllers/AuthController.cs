using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ViraRankCleanApi.Data;
using ViraRankCleanApi.DTOs;
using ViraRankCleanApi.Helpers;
using ViraRankCleanApi.Models;

namespace ViraRankCleanApi.Controllers
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
        public async Task<ActionResult<AuthResponse>> Register(RegisterRequest req)
        {
            if (await _db.Users.AnyAsync(u => u.Email == req.Email))
                return BadRequest("Email already exists.");
            if (await _db.Users.AnyAsync(u => u.UserName == req.UserName))
                return BadRequest("Username already exists.");

            PasswordHelper.CreatePasswordHash(req.Password, out var salt, out var hash);
            var user = new User
            {
                UserName = req.UserName,
                Email = req.Email,
                BirthDate = req.BirthDate,
                Gender = req.Gender,
                PasswordHash = hash,
                PasswordSalt = salt,
                GithubToken = req.GithubToken
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            return Ok(new AuthResponse { Token = GenerateJwt(user), GithubToken = user.GithubToken });
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(LoginRequest req)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == req.Email);
            if (user == null || !PasswordHelper.VerifyPassword(req.Password, user.PasswordSalt, user.PasswordHash))
                return Unauthorized("Invalid email or password.");

            return Ok(new AuthResponse { Token = GenerateJwt(user), GithubToken = user.GithubToken });
        }

        private string GenerateJwt(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
