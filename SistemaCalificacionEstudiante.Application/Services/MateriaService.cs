using SistemaCalificacionEstudiante.Application.DTOs;
using SistemaCalificacionEstudiante.Application.Interfaces;
using SistemaCalificacionEstudiante.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<MateriaDto>> GetAllMateriasAsync()
        {
            var materias = await _materiaRepository.GetAllAsync();

            return materias.Select(m => new MateriaDto
            {
                Id = m.Id,
                Nombre = m.Nombre,
                Creditos = m.Creditos,
                CodigoMateria = m.CodigoMateria,
                ProfesorAsignado = m.ProfesorAsignado
            }).ToList();
        }

        public async Task<MateriaDto> GetMateriaByIdAsync(int id)
        {
            var materia = await _materiaRepository.GetByIdAsync(id);
            if (materia == null) return null;

            return new MateriaDto
            {
                Id = materia.Id,
                Nombre = materia.Nombre,
                Creditos = materia.Creditos,
                CodigoMateria = materia.CodigoMateria,
                ProfesorAsignado = materia.ProfesorAsignado
            };
        }

        public async Task AddMateriaAsync(MateriaDto materiaDto)
        {
            var materia = new Materia
            {
                Nombre = materiaDto.Nombre,
                Creditos = materiaDto.Creditos,
                CodigoMateria = materiaDto.CodigoMateria,
                ProfesorAsignado = materiaDto.ProfesorAsignado
            };

            await _materiaRepository.AddAsync(materia);
        }

        public async Task UpdateMateriaAsync(int id, MateriaDto materiaDto)
        {
            var materia = await _materiaRepository.GetByIdAsync(id);

            if (materia == null)
            {
                return;
            }

            materia.Nombre = materiaDto.Nombre;
            materia.Creditos = materiaDto.Creditos;
            materia.CodigoMateria = materiaDto.CodigoMateria;
            materia.ProfesorAsignado = materiaDto.ProfesorAsignado;

            await _materiaRepository.UpdateAsync(materia);
        }

        public Task DeleteMateriaAsync(int id) => _materiaRepository.DeleteAsync(id);
    }
}