using System.ComponentModel.DataAnnotations;

namespace SistemaCalificacionEstudiante.Web.Models
{
    public class LoginViewModel
    {
        [Required]
        public required string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
