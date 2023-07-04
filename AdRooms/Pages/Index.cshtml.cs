using AdRooms.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace AdRooms.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AppDbContext _dbContext;

        public IndexModel(ILogger<IndexModel> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
            AdListings = new List<AdListing>();
        }

        public List<AdListing> AdListings { get; set; }

        [Column("user_id")]
        public int UserId { get; set; } 
    }
}