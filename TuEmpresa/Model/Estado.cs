namespace TuEmpresa.Model
{
    public class Estado
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Propiedades de navegación
        public ICollection<Solicitud> Solicitudes { get; set; }
        public ICollection<NombreNegocio> NombresNegocios { get; set; }
    }

}
