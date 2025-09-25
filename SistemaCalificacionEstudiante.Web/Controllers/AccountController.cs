using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaCalificacionEstudiante.Domain.Entities;
using SistemaCalificacionEstudiante.Infrastructure.Context;
using SistemaCalificacionEstudiante.Web.Models;
using System.Security.Claims;
using BCrypt.Net;
using System.Threading.Tasks;

namespace SistemaCalificacionEstudiante.Web.Controllers
{
    // Este controlador se encarga del registro y login de usuarios.
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        // Constructor para conectar con la base de datos.
        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        // Muestra la página de registro.
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // Se ejecuta cuando el usuario envía el formulario de registro.
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid) // Si los datos del formulario son correctos...
            {
                // Crea un nuevo usuario.
                var user = new User
                {
                    Username = model.Username,
                    Email = model.Email,
                    // Encripta la contraseña para guardarla de forma segura.
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password)
                };

                // Guarda el nuevo usuario en la base de datos.
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                // Envía al usuario a la página de login.
                return RedirectToAction("Login");
            }
            // Si hay un error, vuelve a mostrar el formulario.
            return View(model);
        }

        // Muestra la página de inicio de sesión.
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Se ejecuta cuando el usuario envía el formulario de login.
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid) // Si los datos del formulario son correctos...
            {
                // Busca al usuario en la base de datos.
                var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == model.Username);

                // Si el usuario existe y la contraseña es correcta...
                if (user != null && BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
                {
                    // Crea una "credencial" para el usuario.
                    var claims = new[] { new Claim(ClaimTypes.Name, user.Username) };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    // Inicia la sesión del usuario.
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    // Lo envía a la página de inicio.
                    return RedirectToAction("Index", "Home");
                }
                // Si algo falla, muestra un mensaje de error.
                ModelState.AddModelError(string.Empty, "La contraseña o el nombre de usuario es incorrecto.");
            }
            // Si hay un error, vuelve a mostrar el formulario.
            return View(model);
        }

        // Se ejecuta cuando el usuario hace clic en "Logout".
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            // Cierra la sesión del usuario.
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            // Lo envía a la página de inicio.
            return RedirectToAction("Index", "Home");
        }
    }
}