using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace AdRooms.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Column("username")]
        public string Username { get; set; }

        [Column("full_name")]
        public string? FullName { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("phone")]
        public string? Phone { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("profile_image")]
        public string? ProfileImage { get; set; }

        [Column("code")]
        public int Code { get; set; }

        [Column("status")]
        public string? Status { get; set; }

        [Column("banned_on")]
        public int? BannedOn { get; set; } = 0;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
