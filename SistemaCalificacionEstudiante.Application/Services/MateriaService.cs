using SistemaCalificacionEstudiante.Application.Interfaces;
using SistemaCalificacionEstudiante.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaCalificacionEstudiante.Application.Services
{
    public class MateriaService : IMateriaService
    {
        private readonly IMateriaRepository _materiaRepository;

        public MateriaService(IMateriaRepository materiaRepository)
        {
            _materiaRepository = materiaRepository;
        }

        public Task<List<Materia>> GetAllMateriasAsync() => _materiaRepository.GetAllAsync();
        public Task<Materia> GetMateriaByIdAsync(int id) => _materiaRepository.GetByIdAsync(id);
        public Task AddMateriaAsync(Materia materia) => _materiaRepository.AddAsync(materia);
        public Task UpdateMateriaAsync(Materia materia) => _materiaRepository.UpdateAsync(materia);
        public Task DeleteMateriaAsync(int id) => _materiaRepository.DeleteAsync(id);
    }
}