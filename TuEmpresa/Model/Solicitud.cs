using System.ComponentModel.DataAnnotations;

namespace TuEmpresa.Model
{
    public class Solicitud
    {
        public int Id { get; set; }
        public DateTime? FechaEnvio { get; set; }
        public DateTime? FechaFinalizacion { get; set; }

        // Claves foráneas
        [Required]
        public int IdEstado { get; set; }
        public Estado Estado { get; set; }

        [Required]
        public int IdPersona { get; set; }
        public Persona Persona { get; set; }

        public int? IdNegocio { get; set; }
        public Negocio Negocio { get; set; }

        public int? IdNotaria { get; set; }
        public Notaria Notaria { get; set; }

        // Propiedades de navegación
        public ICollection<Comentario> Comentarios { get; set; }
    }

}
