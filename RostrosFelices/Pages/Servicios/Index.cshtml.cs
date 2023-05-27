using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RostrosFelices.Data;
using RostrosFelices.Models;

namespace RostrosFelices.Pages.Servicios
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly SumpermarketContext _context;

        public IndexModel(SumpermarketContext context)
        {
            _context = context;
        }
        public IList<Servicio> Servicios { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync()
        {
            Servicios = await _context.Servicios
                .Include(p => p.Cliente)
                .ToListAsync();

            Servicios = await _context.Servicios
               .Include(p => p.Empleado)
               .ToListAsync();

            return Page();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var product = await _context.Servicios.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Servicios.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
