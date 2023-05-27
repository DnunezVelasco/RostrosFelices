using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RostrosFelices.Data;
using RostrosFelices.Models;
using System.Security.Claims;

namespace RostrosFelices.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SumpermarketContext _context;

        [BindProperty]
        public User User { get; set; }

        public LoginModel(SumpermarketContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var registro = await _context.Registros.FirstOrDefaultAsync(r => r.Email == User.Email && r.Password == User.Password);

            if (registro != null)
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "admin"),
                new Claim(ClaimTypes.Email, registro.Email),
            };
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                return RedirectToPage("/Index");
            }

            ModelState.AddModelError(string.Empty, "Credenciales inv�lidas.");
            return Page();
        }
    }
}
