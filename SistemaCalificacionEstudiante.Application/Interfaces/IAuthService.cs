using SistemaCalificacionEstudiante.Application.DTOs;
using SistemaCalificacionEstudiante.Application.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCalificacionEstudiante.Application.Interfaces
{
    public interface IAuthService
    {
        Task<Result> RegisterUserAsync(RegisterUserDto registerDto);
        Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
    }
}
