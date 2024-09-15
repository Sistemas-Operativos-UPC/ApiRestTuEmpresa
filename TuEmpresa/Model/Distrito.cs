namespace TuEmpresa.Model
{
    public class Distrito
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Propiedades de navegación
        public ICollection<Negocio> Negocios { get; set; }
        public ICollection<Persona> Personas { get; set; }
        public ICollection<Notaria> Notarias { get; set; }
    }

}
