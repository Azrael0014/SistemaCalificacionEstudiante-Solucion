using System.ComponentModel.DataAnnotations;

namespace SistemaCalificacionEstudiante.Domain.Entities
{
    public class Materia
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la materia es obligatorio.")]
        [StringLength(100)]
        public string Nombre { get; set; }
    }
}