using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BCryptNet = BCrypt.Net.BCrypt;
namespace AdRooms.Pages
{
    public class ProfilesettingsModel : PageModel
    {
        private readonly AppDbContext _db;
        private readonly ILogger<ProfilesettingsModel> _logger;

        public ProfilesettingsModel(AppDbContext db, ILogger<ProfilesettingsModel> logger)
        {
            _db = db;
            _logger = logger;
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Phone { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string ConfirmPassword { get; set; }

        [BindProperty]
        public IFormFile File { get; set; }

        public IActionResult OnPost()
        {
            var user = _db.Users.FirstOrDefault(u => u.Email == Email);
            if (user == null)
            {
               
                TempData["message"] = "User not found";
                TempData["msg_type"] = "error";
                return RedirectToPage("Index");
            }

            user.Username = Username;
            user.FullName = Name;
            user.Phone = Phone;

            _logger.LogDebug("user name:", Username);
            _logger.LogDebug("user name:", Name);
            _logger.LogDebug("user name:", Phone);

            if (!string.IsNullOrEmpty(Password) && Password == ConfirmPassword)
            {
                string hashedPassword = BCryptNet.HashPassword(Password);
                user.Password = hashedPassword;
            }

            // Save the changes to the database
            _db.SaveChanges();

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
                user.ProfileImage = fileName;
                _db.SaveChanges();
            }

            TempData["message"] = "Profile updated successfully";
            TempData["msg_type"] = "success";

            return RedirectToPage("Index");


        }
        public void OnGet()
        {
        }
    }
}
