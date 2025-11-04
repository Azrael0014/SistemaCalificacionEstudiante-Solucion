using SistemaCalificacionEstudiante.Application.DTOs;
using SistemaCalificacionEstudiante.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaCalificacionEstudiante.Application.Interfaces
{
    public interface IMateriaService
    {
        Task<List<MateriaDto>> GetAllMateriasAsync();

        Task<MateriaDto> GetMateriaByIdAsync(int id);

        Task AddMateriaAsync(MateriaDto materiaDto);

        Task UpdateMateriaAsync(int id, MateriaDto materiaDto);
        Task DeleteMateriaAsync(int id);
    }
}