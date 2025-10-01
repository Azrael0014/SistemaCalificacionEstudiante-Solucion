using SistemaCalificacionEstudiante.Application.Common;
using SistemaCalificacionEstudiante.Application.DTOs;
using SistemaCalificacionEstudiante.Application.Interfaces;
using SistemaCalificacionEstudiante.Domain.Entities;

namespace SistemaCalificacionEstudiante.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Recibe el DTO y devuelve el objeto Result.
        public async Task<Result> RegisterUserAsync(RegisterUserDto registerDto)
        {
            var existingUser = await _userRepository.GetByUsernameAsync(registerDto.Username);
            if (existingUser != null)
            {
                // Devolvemos un resultado de fallo con un mensaje claro.
                return Result.Failure("El nombre de usuario ya está en uso.");
            }

            var user = new User
            {
                Username = registerDto.Username,
                Email = registerDto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password) // FIX: Use BCrypt.Net.BCrypt
            };

            await _userRepository.AddAsync(user);

            // Devolvemos un resultado exitoso.
            return Result.Success();
        }

        public async Task<bool> ValidateCredentialsAsync(string username, string password)
        {
            var user = await _userRepository.GetByUsernameAsync(username);

            if (user == null)
            {
                return false;
            }

            return BCrypt.Net.BCrypt.Verify(password, user.PasswordHash); // FIX: Use BCrypt.Net.BCrypt
        }
    }
}