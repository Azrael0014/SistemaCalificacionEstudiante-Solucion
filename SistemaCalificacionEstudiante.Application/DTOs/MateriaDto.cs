using System.ComponentModel.DataAnnotations;

namespace SistemaCalificacionEstudiante.Application.DTOs
{
    public class MateriaDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la materia es obligatorio.")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La cantidad de créditos es obligatoria.")]
        [Range(1, 10, ErrorMessage = "Los créditos deben estar entre 1 y 10.")]
        public int Creditos { get; set; }

        [Required(ErrorMessage = "El código de la materia es obligatorio.")]
        [StringLength(20, ErrorMessage = "El código no puede tener más de 20 caracteres.")]
        public string CodigoMateria { get; set; }

        [StringLength(100)]
        public string ProfesorAsignado { get; set; }
    }
}