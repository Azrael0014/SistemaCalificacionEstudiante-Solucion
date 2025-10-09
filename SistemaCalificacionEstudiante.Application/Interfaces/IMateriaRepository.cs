using SistemaCalificacionEstudiante.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaCalificacionEstudiante.Application.Interfaces
{
    public interface IMateriaRepository
    {
        Task<Materia> GetByIdAsync(int id);
        Task<List<Materia>> GetAllAsync();
        Task AddAsync(Materia materia);
        Task UpdateAsync(Materia materia);
        Task DeleteAsync(int id);
    }
}