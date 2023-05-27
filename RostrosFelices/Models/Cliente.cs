namespace RostrosFelices.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string NombreCliente { get; set; }
        public string Apellidos { get; set; }
        public long Documento { get; set; }
        public long Numero { get; set; }

        public ICollection<Servicio>? Servicios { get; set; } = default!;

        public ICollection<Empleado>? Empleados { get; set; } = default!;
    }
}
