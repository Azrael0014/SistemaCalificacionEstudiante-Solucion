using Microsoft.AspNetCore.Mvc;
using SistemaCalificacionEstudiante.Infrastructure.Context;
using SistemaCalificacionEstudiante.Domain.Entities;

public class RegisterModel : PageModel
{
    private readonly AppDbContext _context;
    public RegisterModel(AppDbContext context) => _context = context;

    [BindProperty]
    public string Username { get; set; }
    [BindProperty]
    public string Password { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (_context.Users.Any(u => u.Username == Username))
        {
            ModelState.AddModelError("", "Username already exists.");
            return Page();
        }

        var user = new User
        {
            Username = Username,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(Password)
        };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return RedirectToPage("Login");
    }
}