using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using BCryptNet = BCrypt.Net.BCrypt;

namespace AdRooms.Pages
{
    public class LoginModel : PageModel
    {
        private readonly AppDbContext _db;

        public LoginModel(AppDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password.");
                return Page();
            }

            bool passwordValid = BCryptNet.Verify(Password, user.Password);
            if (!passwordValid)
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password.");
                return Page();
            }

            HttpContext.Session.SetString("email", user.Email);
            HttpContext.Session.SetString("password", user.Password);

            string returnUrl = HttpContext.Session.GetString("ReturnUrl");
            if (!string.IsNullOrEmpty(returnUrl))
            {
                HttpContext.Session.Remove("ReturnUrl");
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToPage("/Index");
            }
        }
    }
}