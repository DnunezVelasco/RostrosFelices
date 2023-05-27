using Microsoft.EntityFrameworkCore;
using RostrosFelices.Models;

namespace RostrosFelices.Data
{
    public class SumpermarketContext : DbContext
    {
        public SumpermarketContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Registro> Registros { get; set; }
    }
}
