using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RostrosFelices.Data;
using RostrosFelices.Models;

namespace RostrosFelices.Pages.Empleados
{
    public class CreateModel : PageModel
    {
        private readonly SumpermarketContext _context;

        public CreateModel(SumpermarketContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]

        public Empleado Empleado { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Empleados == null || Empleado == null)
            {
                return Page();
            }

            _context.Empleados.Add(Empleado);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
