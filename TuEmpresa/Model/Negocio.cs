using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TuEmpresa.Model
{
    public class Negocio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Claves foráneas
        [Required]
        public int IdTipoModalidad { get; set; }

        [JsonIgnore]
        public TipoModalidadEmpresarial? TipoModalidadEmpresarial { get; set; }

        [Required]
        public int IdDepartamento { get; set; }

        [JsonIgnore]
        public Departamento? Departamento { get; set; }

        [Required]
        public int IdProvincia { get; set; }

        [JsonIgnore]
        public Provincia? Provincia { get; set; }

        [Required]
        public int IdDistrito { get; set; }

        [JsonIgnore]
        public Distrito? Distrito { get; set; }

        // Propiedades de navegación

        [JsonIgnore]
        public ICollection<NombreNegocio>? NombresNegocios { get; set; }

        [JsonIgnore]
        public ICollection<Solicitud>? Solicitudes { get; set; }
    }

}
