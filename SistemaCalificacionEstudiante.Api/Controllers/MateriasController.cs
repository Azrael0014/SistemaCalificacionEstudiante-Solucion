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
    public class MateriasController : ControllerBase
    {
        private readonly IMateriaService _materiaService;

        public MateriasController(IMateriaService materiaService)
        {
            _materiaService = materiaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMaterias()
        {
            var materias = await _materiaService.GetAllMateriasAsync();
            return Ok(materias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMateriaById(int id)
        {
            var materia = await _materiaService.GetMateriaByIdAsync(id);
            if (materia == null)
            {
                return NotFound(new { Message = "Materia no encontrada." });
            }
            return Ok(materia);
        }

        [HttpPost]
        public async Task<IActionResult> AddMateria([FromBody] MateriaDto materiaDto)
        {
            // La validación usa los atributos del DTO
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _materiaService.AddMateriaAsync(materiaDto);

            // Retorna un Ok (o un CreatedAtAction si prefieres)
            return Ok(new { Message = "Materia creada exitosamente." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMateria(int id, [FromBody] MateriaDto materiaDto)
        {
            if (id != materiaDto.Id)
            {
                return BadRequest(new { Message = "El ID de la materia no coincide." });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _materiaService.UpdateMateriaAsync(id, materiaDto);
            return Ok(new { Message = "Materia actualizada exitosamente." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMateria(int id)
        {
            await _materiaService.DeleteMateriaAsync(id);
            return Ok(new { Message = "Materia eliminada exitosamente." });
        }
    }
}