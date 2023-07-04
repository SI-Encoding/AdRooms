using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace AdRooms.Models
{
    public class AdImage
    {
        [Key]
        [Column("id")]
        public int id { get; set; }

        [ForeignKey("listing_id")]
        [Column("listing_id")]
        public int listing_id { get; set; }

        [Column("image")]
        public string? image { get; set; }

        [Column("created_at")]
        public DateTime? created_at { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime? updated_at { get; set; } = DateTime.UtcNow;
    }
}
