using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using ViraRankCleanApi.Data;
using ViraRankCleanApi.DTOs;

namespace ViraRankCleanApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] 
    public class UsersController : ControllerBase
    {
        private readonly ViraRankContext _db;
        public UsersController(ViraRankContext db) { _db = db; }

        [HttpGet("me")]
        public async Task<ActionResult<ProfileResponse>> GetMe()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var user = await _db.Users.FindAsync(userId);

            if (user == null) return NotFound();

            return Ok(new ProfileResponse
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                BirthDate = user.BirthDate,
                Gender = user.Gender,
                ImageUrl = user.ImageUrl
            });
        }

        
        [HttpPut("me")]
        public async Task<ActionResult<ProfileResponse>> UpdateMe([FromBody] UpdateProfileRequest request)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var userToUpdate = await _db.Users.FindAsync(userId);

            if (userToUpdate == null)
            {
                return NotFound("User not found.");
            }

        
            if (request.UserName != null && userToUpdate.UserName != request.UserName)
            {
                
                if (await _db.Users.AnyAsync(u => u.UserName == request.UserName && u.Id != userId))
                {
                    return Conflict("Username is already taken."); 
                }
                userToUpdate.UserName = request.UserName;
            }

            
            if (request.Email != null && userToUpdate.Email != request.Email)
            {
                
                if (await _db.Users.AnyAsync(u => u.Email == request.Email && u.Id != userId))
                {
                    return Conflict("Email is already taken.");
                }
                userToUpdate.Email = request.Email;
            }

          
            if (request.BirthDate.HasValue)
            {
                userToUpdate.BirthDate = request.BirthDate.Value;
            }
            if (request.Gender.HasValue)
            {
                userToUpdate.Gender = request.Gender.Value;
            }

            
            if (request.ImageUrl != null)
            {
                userToUpdate.ImageUrl = request.ImageUrl;
            }

            await _db.SaveChangesAsync();

            
            return Ok(new ProfileResponse
            {
                Id = userToUpdate.Id,
                UserName = userToUpdate.UserName,
                Email = userToUpdate.Email,
                BirthDate = userToUpdate.BirthDate,
                Gender = userToUpdate.Gender,
                ImageUrl = userToUpdate.ImageUrl
            });
        }
    }
}

