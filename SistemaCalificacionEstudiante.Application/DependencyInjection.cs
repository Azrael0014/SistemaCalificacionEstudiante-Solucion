using Microsoft.Extensions.DependencyInjection;
using SistemaCalificacionEstudiante.Application.Interfaces;
using SistemaCalificacionEstudiante.Application.Services;

namespace SistemaCalificacionEstudiante.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IMateriaService, MateriaService>();
            services.AddScoped<ICalificacionService, CalificacionService>();

            return services;
        }
    }
}