using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RostrosFelices.Models
{
    public class Servicio
    {
        public int Id { get; set; }
        public string NombreDelServicio { get; set; }

        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }

        public int EmpleadoId { get; set; }

        public Cliente Cliente { get; set; }

        public Empleado Empleado { get; set; }


    }
}
