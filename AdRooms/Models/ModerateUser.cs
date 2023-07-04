using System.ComponentModel.DataAnnotations.Schema;

namespace AdRooms.Models
{
    public class ModerateUser
    {
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("admin_id")]
        public int AdminId { get; set; }
        [Column("reason")]
        public string Reason { get; set; }
    }
}
