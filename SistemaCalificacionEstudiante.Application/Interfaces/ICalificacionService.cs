using SistemaCalificacionEstudiante.Application.DTOs;
using SistemaCalificacionEstudiante.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaCalificacionEstudiante.Application.Interfaces
{
    public interface ICalificacionService
    {
        Task<List<CalificacionDto>> GetAllCalificacionesAsync();

        Task<CalificacionDto> GetCalificacionByIdAsync(int id);

        Task AddCalificacionAsync(CalificacionDto calificacionDto);
        Task UpdateCalificacionAsync(int id, CalificacionDto calificacionDto);
        Task DeleteCalificacionAsync(int id);
    }
}