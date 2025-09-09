using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViraRankCleanApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [MaxLength(75)]
        public string Email { get; set; } = string.Empty;

        public DateTime BirthDate { get; set; }

        public bool Gender { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; } = [];

        [Required]
        public byte[] PasswordSalt { get; set; } = [];

        public string? GithubToken { get; set; }

        public string? ImageUrl { get; set; }
    }
}
