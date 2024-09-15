using System.ComponentModel.DataAnnotations;

namespace TuEmpresa.Model
{
    public class Notaria
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Direccion { get; set; }
        public decimal? TarifaSocial { get; set; }

        // Claves foráneas
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
        public ICollection<Solicitud> Solicitudes { get; set; }
    }

}
