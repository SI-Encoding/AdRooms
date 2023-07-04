using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AdRooms.Models;

namespace AdRooms.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly AppDbContext _db;

        public RegisterModel(AppDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public List<string> Errors { get; set; }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string CPassword { get; set; }

        public void OnGet()
        {
            // Code for handling GET request
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Password != CPassword)
            {
                ModelState.AddModelError("Password", "Confirm password not matched!");
                return Page();
            }

            var userWithEmail = await _db.Users.FirstOrDefaultAsync(u => u.Email == Email);
            if (userWithEmail != null)
            {
                ModelState.AddModelError("Email", "Email that you have entered already exists!");
                return Page();
            }

            var encpass = BCrypt.Net.BCrypt.HashPassword(Password);
            int code = new Random().Next(111111, 999999);
            var status = "notverified";

            var user = new User
            {
                Username = Username,
                Email = Email,
                Password = encpass,
                Code = code,
                Status = status,
                UpdatedAt = DateTime.Now
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            HttpContext.Session.SetString("email", Email);
            HttpContext.Session.SetString("password", Password);

            return RedirectToPage("/Index");
        }
    }
}