using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TuEmpresa.Model
{
    public class Persona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string PrimerNombre { get; set; }

        [MaxLength(50)]
        public string? SegundoNombre { get; set; }

        [Required]
        [MaxLength(50)]
        public string ApellidoPaterno { get; set; }

        [Required]
        [MaxLength(50)]
        public string ApellidoMaterno { get; set; }

        [Required]
        [MaxLength(20)]
        public string NumeroDocumento { get; set; }

        [Required]
        [MaxLength(50)]
        // Quita [JsonIgnore] para permitir la deserialización
        public string Contrasena { get; set; }

        [Required]
        public int Celular { get; set; }

        // Claves Foráneas
        [Required]
        public int IdTipoDocumento { get; set; }

        [JsonIgnore]
        public TipoDocumento? TipoDocumento { get; set; }

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

        [Required]
        public int IdTipoPersona { get; set; }

        [JsonIgnore]
        public TipoPersona? TipoPersona { get; set; }

        // Propiedades de Navegación
        [JsonIgnore]
        public ICollection<Solicitud>? Solicitudes { get; set; }
    }

}
