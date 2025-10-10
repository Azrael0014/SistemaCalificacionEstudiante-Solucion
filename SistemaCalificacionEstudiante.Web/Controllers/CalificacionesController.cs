using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaCalificacionEstudiante.Application.Interfaces;
using SistemaCalificacionEstudiante.Domain.Entities;
using SistemaCalificacionEstudiante.Web.Models; 
using System.Threading.Tasks;

namespace SistemaCalificacionEstudiante.Web.Controllers
{
    [Authorize]
    public class CalificacionesController : Controller
    {
        private readonly ICalificacionService _calificacionService;
        private readonly IStudentService _studentService;
        private readonly IMateriaService _materiaService;

        public CalificacionesController(ICalificacionService calificacionService, IStudentService studentService, IMateriaService materiaService)
        {
            _calificacionService = calificacionService;
            _studentService = studentService;
            _materiaService = materiaService;
        }

        public IActionResult Index() => View();

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var calificaciones = await _calificacionService.GetAllCalificacionesAsync();
            return new JsonResult(new { data = calificaciones });
        }

        // GET: Muestra el formulario con un ViewModel vacío
        public async Task<IActionResult> Create()
        {
            await LoadDropdownData();
            return View(new CalificacionViewModel());
        }

        // POST: Recibe el ViewModel del formulario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CalificacionViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Mapea del ViewModel a la Entidad de la base de datos
                var calificacion = new Calificacion
                {
                    EstudianteId = viewModel.EstudianteId,
                    MateriaId = viewModel.MateriaId,
                    Calificacion1 = viewModel.Calificacion1,
                    Calificacion2 = viewModel.Calificacion2,
                    Calificacion3 = viewModel.Calificacion3,
                    Calificacion4 = viewModel.Calificacion4,
                    Examen = viewModel.Examen
                };

                await _calificacionService.AddCalificacionAsync(calificacion);
                return RedirectToAction(nameof(Index));
            }

            // Si hay un error, recarga los dropdowns y devuelve la vista con el viewModel y los errores
            await LoadDropdownData();
            return View(viewModel);
        }

        // GET: Carga los datos y los mapea a un ViewModel para la vista de edición
        public async Task<IActionResult> Edit(int id)
        {
            var calificacion = await _calificacionService.GetCalificacionByIdAsync(id);
            if (calificacion == null) return NotFound();

            var viewModel = new CalificacionViewModel
            {
                Id = calificacion.Id,
                EstudianteId = calificacion.EstudianteId,
                MateriaId = calificacion.MateriaId,
                Calificacion1 = calificacion.Calificacion1,
                Calificacion2 = calificacion.Calificacion2,
                Calificacion3 = calificacion.Calificacion3,
                Calificacion4 = calificacion.Calificacion4,
                Examen = calificacion.Examen
            };

            ViewBag.NombreEstudiante = calificacion.Estudiante.FullName;
            ViewBag.NombreMateria = calificacion.Materia.Nombre;

            await LoadDropdownData();
            return View(viewModel);
        }

        // POST: Recibe el ViewModel de la edición
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CalificacionViewModel viewModel)
        {
            if (id != viewModel.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var calificacion = new Calificacion
                {
                    Id = viewModel.Id,
                    EstudianteId = viewModel.EstudianteId,
                    MateriaId = viewModel.MateriaId,
                    Calificacion1 = viewModel.Calificacion1,
                    Calificacion2 = viewModel.Calificacion2,
                    Calificacion3 = viewModel.Calificacion3,
                    Calificacion4 = viewModel.Calificacion4,
                    Examen = viewModel.Examen
                };

                await _calificacionService.UpdateCalificacionAsync(calificacion);
                return RedirectToAction(nameof(Index));
            }
            await LoadDropdownData();
            return View(viewModel);
        }

        // El delete no necesita ViewModel, ya que solo muestra y confirma
        public async Task<IActionResult> Delete(int id)
        {
            var calificacion = await _calificacionService.GetCalificacionByIdAsync(id);
            if (calificacion == null) return NotFound();
            return View(calificacion);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _calificacionService.DeleteCalificacionAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task LoadDropdownData()
        {
            ViewBag.Estudiantes = new SelectList(await _studentService.GetAllStudentsAsync(), "Id", "FullName");
            ViewBag.Materias = new SelectList(await _materiaService.GetAllMateriasAsync(), "Id", "Nombre");
        }
    }
}