using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AdRooms.Models
{
    public class FavouriteAd
    {
        [ForeignKey("listing_id")]
        [Column("listing_id")]
        public int ListingId { get; set; }

        [ForeignKey("user_id")]
        [Column("user_id")]
        public int UserId { get; set; }
    }
}
