using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AdRooms.Models;

namespace AdRooms.Pages
{
    public class PostAdModel : PageModel
    {
        private readonly AppDbContext _db;
        private readonly ILogger<PostAdModel> _logger;

        public PostAdModel(AppDbContext db, ILogger<PostAdModel> logger)
        {
            _db = db;
            _logger = logger;

            if (_logger is ILogger loggerImplementation)
            {
                loggerImplementation.Log(LogLevel.Debug, "Example log message");
            }
        }

        public void OnGet()
        {
            // Page load logic
        }

        [BindProperty]
        public string Title { get; set; }

        [BindProperty]
        public int CategoryId { get; set; }

        [BindProperty]
        public decimal Price { get; set; }

        [BindProperty]
        public string Content { get; set; }

        [BindProperty]
        public IFormFile File { get; set; }

        [BindProperty]
        public string Email { get; set; }

        public IActionResult OnPost()
        {
            _logger.LogDebug("OnPost method called");

            _logger.LogDebug("Title: " + Title);
            _logger.LogDebug("CategoryId: " + CategoryId);
            _logger.LogDebug("Price: " + Price);
            _logger.LogDebug("Content: " + Content);
            _logger.LogDebug("Email: " + Email);
           
            var user = _db.Users.FirstOrDefault(u => u.Email == Email);
            if (user == null)
            {
                TempData["message"] = "User not found";
                TempData["msg_type"] = "error";
                return RedirectToPage("Index");
            }

            var ad = new AdListing
            {
                Title = Title,
                CategoryId = CategoryId,
                Price = Price,
                Content = Content,
                Phone = user.Phone,
                UserId = user.Id
            };

            _db.AdListings.Add(ad);
            _db.SaveChanges();

           
            TempData["message"] = "Ad posted successfully";
            TempData["msg_type"] = "success";

            // Accessing the uploaded file
            if (File != null && File.Length > 0)
            {
                var fileName = Path.GetFileName(File.FileName);
                // Save the file to a specific directory
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    File.CopyTo(fileStream);
                }
                // Save the file information to the database or perform other operations
                var adImage = new AdImage
                {
                    listing_id = ad.Id,
                    image = fileName
                };
                _db.AdImages.Add(adImage);
                _db.SaveChanges();
            }

            _logger.LogDebug("Ad Title: " + ad.Title);
            _logger.LogDebug("Ad CategoryId: " + ad.CategoryId);
            _logger.LogDebug("Ad Price: " + ad.Price);
            _logger.LogDebug("Ad Content: " + ad.Content);
            _logger.LogDebug("Ad Phone: " + ad.Phone);
            _logger.LogDebug("Ad UserId: " + ad.UserId);

            return RedirectToPage("Index");
        }
    }
}