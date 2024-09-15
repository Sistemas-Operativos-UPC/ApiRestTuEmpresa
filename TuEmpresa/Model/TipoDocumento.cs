namespace TuEmpresa.Model
{
    public class TipoDocumento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        // Propiedades de navegación
        public ICollection<Persona> Personas { get; set; }
    }

}
