namespace TuEmpresa.Model
{
    public class TipoPersona
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Propiedades de navegación
        public ICollection<Persona> Personas { get; set; }
    }

}
