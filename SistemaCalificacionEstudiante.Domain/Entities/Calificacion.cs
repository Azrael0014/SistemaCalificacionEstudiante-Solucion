using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCalificacionEstudiante.Domain.Entities
{
    public class Calificacion
    {
        public int Id { get; set; }

        
        [Required(ErrorMessage = "Debe seleccionar un estudiante.")]
        public int EstudianteId { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una materia.")]
        public int MateriaId { get; set; }

        
        public virtual Student Estudiante { get; set; }
        public virtual Materia Materia { get; set; }

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

        [NotMapped] 
        public double TotalCalificacion
        {
            get
            {
                var promedioParciales = (Calificacion1 + Calificacion2 + Calificacion3 + Calificacion4) / 4;
                return (promedioParciales * 0.70) + (Examen * 0.30);
            }
        }

        [NotMapped]
        public string Clasificacion
        {
            get
            {
                if (TotalCalificacion >= 90) return "A";
                if (TotalCalificacion >= 80) return "B";
                if (TotalCalificacion >= 70) return "C";
                return "F";
            }
        }

        [NotMapped]
        public string Estado => TotalCalificacion >= 70 ? "Aprobado" : "Reprobado";
    }
}