using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RostrosFelices.Data;
using RostrosFelices.Models;

namespace RostrosFelices.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SumpermarketContext _context;
        public RegisterModel(SumpermarketContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Registro Registro { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid || _context.Registros == null || Registro == null)
            {
                return Page();
            }
            _context.Registros.Add(Registro);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Account/Login");
        }
    }
}
