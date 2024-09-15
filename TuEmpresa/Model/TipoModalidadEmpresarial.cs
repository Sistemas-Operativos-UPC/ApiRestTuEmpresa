namespace TuEmpresa.Model
{
    public class TipoModalidadEmpresarial
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Propiedades de navegación
        public ICollection<Negocio> Negocios { get; set; }
    }

}
