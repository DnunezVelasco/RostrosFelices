using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RostrosFelices.Data;
using RostrosFelices.Models;

namespace RostrosFelices.Pages.Servicios
{
    public class DeleteModel : PageModel
    {
        private readonly SumpermarketContext _context;

        public DeleteModel(SumpermarketContext context)
        {
            _context = context;
        }
        [BindProperty]

        public Servicio Servicio { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Servicios == null)
            {
                return NotFound();
            }
            var category = await _context.Servicios.FirstOrDefaultAsync(m => m.Id == id);

            if (category == null)
            {
                return NotFound();
            }
            else
            {
                Servicio = category;
            }
            return Page();

        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Servicios == null)
            {
                return NotFound();
            }
            var category = await _context.Servicios.FindAsync(id);

            if (category != null)
            {
                Servicio = category;
                _context.Servicios.Remove(Servicio);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
