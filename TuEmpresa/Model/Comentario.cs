using System.ComponentModel.DataAnnotations;

namespace TuEmpresa.Model
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Contenido { get; set; }
        public DateTime? FechaCreacion { get; set; }

        // Clave foránea
        [Required]
        public int IdSolicitud { get; set; }
        public Solicitud Solicitud { get; set; }
    }

}
