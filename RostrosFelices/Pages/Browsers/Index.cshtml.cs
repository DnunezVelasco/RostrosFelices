using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RostrosFelices.Data;
using RostrosFelices.Models;

namespace RostrosFelices.Pages.Browsers
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly SumpermarketContext _dbContext;

        public IndexModel(SumpermarketContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Servicio> Servicios { get; set; }
        public async Task OnGet()
        {
            Servicios = await _dbContext.Servicios
                .Include(s => s.Cliente)
                .Include(s => s.Empleado)
                .ToListAsync();
        }

       
    }
}
