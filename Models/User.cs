using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViraRankApi.Models
{
    [Table("USER")]
    public class User
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [Column("UserName", TypeName = "varchar(50)")]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [Column("Email", TypeName = "varchar(75)")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Column("birth_date", TypeName = "date")]
        public DateTime BirthDate { get; set; }

        [Required]
        [Column("gender", TypeName = "bit")]
        public bool Gender { get; set; }

       
        [Column("password_hash", TypeName = "varbinary(64)")]
        public byte[]? PasswordHash { get; set; }

        [Column("password_salt", TypeName = "varbinary(32)")]
        public byte[]? PasswordSalt { get; set; }
    }
}
