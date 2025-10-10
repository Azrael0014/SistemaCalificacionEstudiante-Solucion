using SistemaCalificacionEstudiante.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaCalificacionEstudiante.Application.Interfaces
{
    public interface ICalificacionRepository
    {
        Task<Calificacion> GetByIdAsync(int id);
        Task<List<Calificacion>> GetAllWithIncludesAsync();
        Task AddAsync(Calificacion calificacion);
        Task UpdateAsync(Calificacion calificacion);
        Task DeleteAsync(int id);
    }
}