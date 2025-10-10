namespace SistemaCalificacionEstudiante.Application.DTOs
{
    public class StudentDto
    {
        public string Matricula { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Carrera { get; set; }
        public string Email { get; set; }
        public DateTime FechaInscripcion { get; set; } = DateTime.Today;
    }
}