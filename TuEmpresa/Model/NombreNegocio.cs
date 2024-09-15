using System.ComponentModel.DataAnnotations;

namespace TuEmpresa.Model
{
    public class NombreNegocio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }

        // Claves foráneas
        [Required]
        public int IdNegocio { get; set; }
        public Negocio Negocio { get; set; }

        [Required]
        public int IdEstado { get; set; }
        public Estado Estado { get; set; }
    }

}
