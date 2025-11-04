using SistemaCalificacionEstudiante.Application.DTOs;
using SistemaCalificacionEstudiante.Application.Interfaces;
using SistemaCalificacionEstudiante.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaCalificacionEstudiante.Application.Services
{
    public class CalificacionService : ICalificacionService
    {
        private readonly ICalificacionRepository _calificacionRepository;

        public CalificacionService(ICalificacionRepository calificacionRepository)
        {
            _calificacionRepository = calificacionRepository;
        }

        public async Task<List<CalificacionDto>> GetAllCalificacionesAsync()
        {
            var calificaciones = await _calificacionRepository.GetAllWithIncludesAsync();

            return calificaciones.Select(c => new CalificacionDto
            {
                Id = c.Id,
                IdEstudiante = c.EstudianteId,

                NombreEstudiante = c.Estudiante != null ? c.Estudiante.FullName : "N/A",

                IdMateria = c.MateriaId,
                NombreMateria = c.Materia != null ? c.Materia.Nombre : "N/A",

                Calificacion1 = c.Calificacion1,
                Calificacion2 = c.Calificacion2,
                Calificacion3 = c.Calificacion3,
                Calificacion4 = c.Calificacion4,
                Examen = c.Examen,

                TotalCalificacion = c.TotalCalificacion,
                Clasificacion = c.Clasificacion,
                Estado = c.Estado
            }).ToList();
        }

        public async Task<CalificacionDto> GetCalificacionByIdAsync(int id)
        {
            var c = await _calificacionRepository.GetByIdAsync(id);
            if (c == null) return null;

            return new CalificacionDto
            {
                Id = c.Id,
                IdEstudiante = c.EstudianteId,

                NombreEstudiante = c.Estudiante != null ? c.Estudiante.FullName : "N/A",

                IdMateria = c.MateriaId,
                NombreMateria = c.Materia != null ? c.Materia.Nombre : "N/A",

                Calificacion1 = c.Calificacion1,
                Calificacion2 = c.Calificacion2,
                Calificacion3 = c.Calificacion3,
                Calificacion4 = c.Calificacion4,
                Examen = c.Examen,

                TotalCalificacion = c.TotalCalificacion,
                Clasificacion = c.Clasificacion,
                Estado = c.Estado
            };
        }

        public async Task AddCalificacionAsync(CalificacionDto calificacionDto)
        {
            var calificacion = new Calificacion
            {
                EstudianteId = calificacionDto.IdEstudiante,
                MateriaId = calificacionDto.IdMateria,

                Calificacion1 = calificacionDto.Calificacion1,
                Calificacion2 = calificacionDto.Calificacion2,
                Calificacion3 = calificacionDto.Calificacion3,
                Calificacion4 = calificacionDto.Calificacion4,
                Examen = calificacionDto.Examen
            };

            await _calificacionRepository.AddAsync(calificacion);
        }

        public async Task UpdateCalificacionAsync(int id, CalificacionDto calificacionDto)
        {
            var calificacion = await _calificacionRepository.GetByIdAsync(id);

            if (calificacion == null)
            {
                throw new System.Exception("Calificación no encontrada");
            }

            calificacion.EstudianteId = calificacionDto.IdEstudiante;
            calificacion.MateriaId = calificacionDto.IdMateria;

            calificacion.Calificacion1 = calificacionDto.Calificacion1;
            calificacion.Calificacion2 = calificacionDto.Calificacion2;
            calificacion.Calificacion3 = calificacionDto.Calificacion3;
            calificacion.Calificacion4 = calificacionDto.Calificacion4;
            calificacion.Examen = calificacionDto.Examen;

            await _calificacionRepository.UpdateAsync(calificacion);
        }

        public Task DeleteCalificacionAsync(int id) => _calificacionRepository.DeleteAsync(id);
    }
}