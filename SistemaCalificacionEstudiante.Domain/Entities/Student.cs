using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCalificacionEstudiante.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La matrícula es obligatoria.")]
        [StringLength(20, ErrorMessage = "La matrícula no puede tener más de 20 caracteres.")]
        public string Matricula { get; set; }

        [MinLength(3)]
        public string? FullName { get; set; }
        public int Age { get; set; }
        public string? Carrera { get; set; }
        [Required(ErrorMessage = "El email es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del email no es válido.")]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaInscripcion { get; set; } = DateTime.Today;
        public virtual ICollection<Calificacion> Calificaciones { get; set; } = new List<Calificacion>();
    }
}
