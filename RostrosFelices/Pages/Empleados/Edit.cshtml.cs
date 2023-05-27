using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RostrosFelices.Data;
using RostrosFelices.Models;

namespace RostrosFelices.Pages.Empleados
{
    public class EditModel : PageModel
    {
        private readonly SumpermarketContext _context;


        public EditModel(SumpermarketContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Empleado Empleado { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Empleados == null)
            {
                return NotFound();
            }
            var category = await _context.Empleados.FirstOrDefaultAsync(m => m.Id == id);

            if (category == null)
            {
                return NotFound();
            }
            else
            {
                Empleado = category;
            }
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Attach(Empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(Empleado.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");

        }
        private bool CategoryExists(int id)
        {
            return (_context.Empleados?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
