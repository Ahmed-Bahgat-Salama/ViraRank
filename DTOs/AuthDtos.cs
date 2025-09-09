using System.ComponentModel.DataAnnotations;

namespace ViraRankCleanApi.DTOs
{
    public class RegisterRequest
    {
        [Required] public string UserName { get; set; } = "";
        [Required][EmailAddress] public string Email { get; set; } = "";
        [Required] public DateTime BirthDate { get; set; }
        [Required] public bool Gender { get; set; }
        [Required] public string Password { get; set; } = "";
        [Required] public string? GithubToken { get; set; }
    }

    public class LoginRequest
    {
        [Required][EmailAddress] public string Email { get; set; } = "";
        [Required] public string Password { get; set; } = "";
    }

    public class AuthResponse
    {
        public string Token { get; set; } = "";
        public string? GithubToken { get; set; }
    }
}
