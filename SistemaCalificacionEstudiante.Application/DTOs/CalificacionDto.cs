using System.ComponentModel.DataAnnotations;

namespace SistemaCalificacionEstudiante.Application.DTOs
{
    public class CalificacionDto
    {
        public int Id { get; set; }

        [Required]
        public int IdEstudiante { get; set; }
        public string? NombreEstudiante { get; set; } 

        [Required]
        public int IdMateria { get; set; }
        public string? NombreMateria { get; set; } 

        [Required]
        [Range(0, 100)]
        public double Calificacion1 { get; set; }

        [Required]
        [Range(0, 100)]
        public double Calificacion2 { get; set; }

        [Required]
        [Range(0, 100)]
        public double Calificacion3 { get; set; }

        [Required]
        [Range(0, 100)]
        public double Calificacion4 { get; set; }

        [Required]
        [Range(0, 100)]
        public double Examen { get; set; }

        public double TotalCalificacion { get; set; }
        public string? Clasificacion { get; set; }
        public string? Estado { get; set; }
    }
}