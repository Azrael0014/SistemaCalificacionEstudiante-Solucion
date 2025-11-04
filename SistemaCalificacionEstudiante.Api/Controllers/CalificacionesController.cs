using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaCalificacionEstudiante.Application.DTOs;
using SistemaCalificacionEstudiante.Application.Interfaces;
using System.Threading.Tasks;

namespace SistemaCalificacionEstudiante.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CalificacionesController : ControllerBase
    {
        private readonly ICalificacionService _calificacionService;

        public CalificacionesController(ICalificacionService calificacionService)
        {
            _calificacionService = calificacionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCalificaciones()
        {
            var calificaciones = await _calificacionService.GetAllCalificacionesAsync();
            return Ok(calificaciones);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCalificacionById(int id)
        {
            var calificacion = await _calificacionService.GetCalificacionByIdAsync(id);
            if (calificacion == null)
            {
                return NotFound(new { Message = "Calificación no encontrada." });
            }
            return Ok(calificacion);
        }

        [HttpPost]
        public async Task<IActionResult> AddCalificacion([FromBody] CalificacionDto calificacionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _calificacionService.AddCalificacionAsync(calificacionDto);
            return Ok(new { Message = "Calificación agregada exitosamente." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCalificacion(int id, [FromBody] CalificacionDto calificacionDto)
        {
            if (id != calificacionDto.Id)
            {
                return BadRequest(new { Message = "El ID de la calificación no coincide." });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _calificacionService.UpdateCalificacionAsync(id, calificacionDto);
            return Ok(new { Message = "Calificación actualizada exitosamente." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalificacion(int id)
        {
            await _calificacionService.DeleteCalificacionAsync(id);
            return Ok(new { Message = "Calificación eliminada exitosamente." });
        }
    }
}