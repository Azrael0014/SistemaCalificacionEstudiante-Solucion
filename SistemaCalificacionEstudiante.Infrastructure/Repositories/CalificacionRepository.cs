using Microsoft.EntityFrameworkCore;
using SistemaCalificacionEstudiante.Application.Interfaces;
using SistemaCalificacionEstudiante.Domain.Entities;
using SistemaCalificacionEstudiante.Infrastructure.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaCalificacionEstudiante.Infrastructure.Repositories
{
    public class CalificacionRepository : ICalificacionRepository
    {
        private readonly AppDbContext _context;

        public CalificacionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Calificacion> GetByIdAsync(int id)
        {
            return await _context.Calificaciones
                .Include(c => c.Estudiante)
                .Include(c => c.Materia)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Calificacion>> GetAllWithIncludesAsync()
        {
            return await _context.Calificaciones
                                 .Include(c => c.Estudiante)
                                 .Include(c => c.Materia)
                                 .ToListAsync();
        }

        public async Task AddAsync(Calificacion calificacion)
        {
            await _context.Calificaciones.AddAsync(calificacion);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Calificacion calificacion)
        {
            _context.Entry(calificacion).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var calificacion = await _context.Calificaciones.FindAsync(id);
            if (calificacion != null)
            {
                _context.Calificaciones.Remove(calificacion);
                await _context.SaveChangesAsync();
            }
        }
    }
}