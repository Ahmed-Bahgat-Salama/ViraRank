namespace ViraRankCleanApi.DTOs
{
   
    public class ProfileResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; } = "";
        public string Email { get; set; } = "";
        public DateTime BirthDate { get; set; }
        public bool Gender { get; set; }
        public string? ImageUrl { get; set; }
    }
    public class UpdateProfileRequest
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public DateTime? BirthDate { get; set; } 
        public bool? Gender { get; set; }
        public string? ImageUrl { get; set; }
    }
}

