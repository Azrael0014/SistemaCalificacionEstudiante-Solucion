using Microsoft.EntityFrameworkCore;
using SistemaCalificacionEstudiante.Application.Interfaces;
using SistemaCalificacionEstudiante.Domain.Entities;
using SistemaCalificacionEstudiante.Infrastructure.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaCalificacionEstudiante.Infrastructure.Repositories
{
    public class MateriaRepository : IMateriaRepository
    {
        private readonly AppDbContext _context;

        public MateriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Materia> GetByIdAsync(int id) => await _context.Materias.FindAsync(id);

        public async Task<List<Materia>> GetAllAsync() => await _context.Materias.ToListAsync();

        public async Task AddAsync(Materia materia)
        {
            await _context.Materias.AddAsync(materia);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Materia materia)
        {
            _context.Entry(materia).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var materia = await _context.Materias.FindAsync(id);
            if (materia != null)
            {
                _context.Materias.Remove(materia);
                await _context.SaveChangesAsync();
            }
        }
    }
}