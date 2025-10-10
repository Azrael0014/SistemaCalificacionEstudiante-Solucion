using SistemaCalificacionEstudiante.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaCalificacionEstudiante.Application.Interfaces
{
    public interface IMateriaService
    {
        Task<List<Materia>> GetAllMateriasAsync();
        Task<Materia> GetMateriaByIdAsync(int id);
        Task AddMateriaAsync(Materia materia);
        Task UpdateMateriaAsync(Materia materia);
        Task DeleteMateriaAsync(int id);
    }
}