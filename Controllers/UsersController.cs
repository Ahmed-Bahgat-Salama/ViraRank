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
    }
}
