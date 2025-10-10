using System.ComponentModel.DataAnnotations;

namespace SistemaCalificacionEstudiante.Web.Models
{
    public class CalificacionViewModel
    {
        public int Id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un estudiante.")]
        public int EstudianteId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una materia.")]
        public int MateriaId { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "La calificación debe estar entre 0 y 100.")]
        public double Calificacion1 { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "La calificación debe estar entre 0 y 100.")]
        public double Calificacion2 { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "La calificación debe estar entre 0 y 100.")]
        public double Calificacion3 { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "La calificación debe estar entre 0 y 100.")]
        public double Calificacion4 { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "La calificación del examen debe estar entre 0 y 100.")]
        public double Examen { get; set; }
    }
}