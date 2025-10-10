using SistemaCalificacionEstudiante.Application.Interfaces;
using SistemaCalificacionEstudiante.Domain.Entities;
using System.Collections.Generic;
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

        public Task<List<Calificacion>> GetAllCalificacionesAsync() => _calificacionRepository.GetAllWithIncludesAsync();
        public Task<Calificacion> GetCalificacionByIdAsync(int id) => _calificacionRepository.GetByIdAsync(id);
        public Task AddCalificacionAsync(Calificacion calificacion) => _calificacionRepository.AddAsync(calificacion);
        public Task UpdateCalificacionAsync(Calificacion calificacion) => _calificacionRepository.UpdateAsync(calificacion);
        public Task DeleteCalificacionAsync(int id) => _calificacionRepository.DeleteAsync(id);
    }
}