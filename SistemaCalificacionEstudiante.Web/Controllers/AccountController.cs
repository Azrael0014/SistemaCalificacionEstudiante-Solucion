using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SistemaCalificacionEstudiante.Application.DTOs;
using SistemaCalificacionEstudiante.Application.Interfaces;
using SistemaCalificacionEstudiante.Web.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SistemaCalificacionEstudiante.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var registerDto = new RegisterUserDto
                {
                    Username = model.Username,
                    Email = model.Email,
                    Password = model.Password
                };

                // 1. Recibimos el objeto 'Result' del servicio.
                var result = await _authService.RegisterUserAsync(registerDto);

                // 2. Verificamos si la operación fue exitosa.
                if (result.IsSuccess)
                {
                    return RedirectToAction("Login");
                }

                // 3. Si no fue exitosa, mostramos el error que nos dio el servicio.
                ModelState.AddModelError(string.Empty, result.Error);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var isValid = await _authService.ValidateCredentialsAsync(model.Username, model.Password);
                if (isValid)
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, model.Username) };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "La contraseña o el nombre de usuario es incorrecto.");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}