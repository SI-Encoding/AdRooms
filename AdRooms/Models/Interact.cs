using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdRooms.Models
{
    public class Interact
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("AdListing")]
        [Column("listing_id")]
        public int ListingId { get; set; }

        [ForeignKey("user_id")]
        [Column("user_id")]
        public int UserId { get; set; }

        [Column("rating")]
        public int? Rating { get; set; }

        [Column("comments")]
        public string? Comments { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        public AdListing AdListing { get; set; }
    }
}
