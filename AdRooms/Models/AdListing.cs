using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdRooms.Models
{
    public class AdListing
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("category_id")]
        
        [Column("category_id")]
        public int? CategoryId { get; set; }

        [ForeignKey("user_id")]

        [Column("user_id")]
        public int? UserId { get; set; }

        [Column("title")]
        public string? Title { get; set; }

        [Column("content")]
        public string? Content { get; set; }

        [Column("price")]
        public decimal? Price { get; set; }

        [Column("phone")]
        public string? Phone { get; set; }

        [Column("country")]
        public string? Country { get; set; } = "Canada";

        [Column("state")]
        public string? State { get; set; } = "Edmonton";

        [Column("city")]
        public string? City { get; set; } = "Vancouver";

        [Column("active_on")]
        public int? ActiveOn { get; set; } = 1;

        [Column("featured_on")]
        public int? FeaturedOn { get; set; } = 0;

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Interact> Interacts { get; set; }

    }
}
