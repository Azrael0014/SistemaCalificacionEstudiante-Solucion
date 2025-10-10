using SistemaCalificacionEstudiante.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaCalificacionEstudiante.Application.Interfaces
{
    public interface ICalificacionService
    {
        Task<List<Calificacion>> GetAllCalificacionesAsync();
        Task<Calificacion> GetCalificacionByIdAsync(int id);
        Task AddCalificacionAsync(Calificacion calificacion);
        Task UpdateCalificacionAsync(Calificacion calificacion);
        Task DeleteCalificacionAsync(int id);
    }
}