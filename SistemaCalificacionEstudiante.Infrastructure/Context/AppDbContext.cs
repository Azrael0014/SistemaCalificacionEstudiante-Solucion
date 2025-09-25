using Microsoft.EntityFrameworkCore;
using SistemaCalificacionEstudiante.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCalificacionEstudiante.Infrastructure.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
