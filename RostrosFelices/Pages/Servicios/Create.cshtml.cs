using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RostrosFelices.Data;
using RostrosFelices.Models;

namespace RostrosFelices.Pages.Servicios
{
    public class CreateModel : PageModel
    {
        private readonly SumpermarketContext _context;

        public CreateModel(SumpermarketContext context)
        {
            _context = context;
        }
        public List<Cliente> CategoryLis { get; set; }

        public List<Empleado> CategoryList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            CategoryLis = await _context.Clientes.ToListAsync();

            CategoryList = await _context.Empleados.ToListAsync();

            return Page();
        }


        [BindProperty]

        public Servicio Servicio { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Servicios == null || Servicio == null)
            {
                //return Page();
            }

            _context.Servicios.Add(Servicio);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
