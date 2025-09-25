using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using SistemaCalificacionEstudiante.Infrastructure.Context;

public class LoginModel : PageModel
{
    private readonly AppDbContext _context;
    public LoginModel(AppDbContext context) => _context = context;

    [BindProperty]
    public string Username { get; set; }
    [BindProperty]
    public string Password { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        var user = _context.Users.FirstOrDefault(u => u.Username == Username);
        if (user == null || !BCrypt.Net.BCrypt.Verify(Password, user.PasswordHash))
        {
            ModelState.AddModelError("", "Invalid login attempt.");
            return Page();
        }

        var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Username) };
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
        return RedirectToPage("Index");
    }
}