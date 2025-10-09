using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaCalificacionEstudiante.Application.Interfaces;
using SistemaCalificacionEstudiante.Domain.Entities;
using System.Threading.Tasks;

[Authorize]
public class MateriasController : Controller
{
    private readonly IMateriaService _materiaService;

    public MateriasController(IMateriaService materiaService)
    {
        _materiaService = materiaService;
    }

    public IActionResult Index() => View();

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var materias = await _materiaService.GetAllMateriasAsync();
        return new JsonResult(new { data = materias });
    }

    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Nombre,Creditos,CodigoMateria,ProfesorAsignado")] Materia materia)
    {
        if (ModelState.IsValid)
        {
            await _materiaService.AddMateriaAsync(materia);
            return RedirectToAction(nameof(Index));
        }
        return View(materia);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var materia = await _materiaService.GetMateriaByIdAsync(id);
        if (materia == null) return NotFound();
        return View(materia);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Creditos,CodigoMateria,ProfesorAsignado")] Materia materia)
    {
        if (id != materia.Id) return NotFound();
        if (ModelState.IsValid)
        {
            await _materiaService.UpdateMateriaAsync(materia);
            return RedirectToAction(nameof(Index));
        }
        return View(materia);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var materia = await _materiaService.GetMateriaByIdAsync(id);
        if (materia == null) return NotFound();
        return View(materia);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _materiaService.DeleteMateriaAsync(id);
        return RedirectToAction(nameof(Index));
    }
}