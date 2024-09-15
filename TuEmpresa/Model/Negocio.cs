using System.ComponentModel.DataAnnotations;

namespace TuEmpresa.Model
{
    public class Negocio
    {
        public int Id { get; set; }

        // Claves foráneas
        [Required]
        public int IdTipoModalidad { get; set; }
        public TipoModalidadEmpresarial TipoModalidadEmpresarial { get; set; }

        [Required]
        public int IdDepartamento { get; set; }
        public Departamento Departamento { get; set; }

        [Required]
        public int IdProvincia { get; set; }
        public Provincia Provincia { get; set; }

        [Required]
        public int IdDistrito { get; set; }
        public Distrito Distrito { get; set; }

        // Propiedades de navegación
        public ICollection<NombreNegocio> NombresNegocios { get; set; }
        public ICollection<Solicitud> Solicitudes { get; set; }
    }

}
