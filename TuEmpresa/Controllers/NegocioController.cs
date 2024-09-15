using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TuEmpresa.Model;
using TuEmpresa.Services;

namespace TuEmpresa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NegocioController : ControllerBase
    {
        private readonly INegocioService _negocioService;

        public NegocioController(INegocioService negocioService)
        {
            _negocioService = negocioService;
        }

        // GET: api/Negocios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Negocio>>> GetNegocios()
        {
            var negocios = await _negocioService.GetAllNegociosAsync();
            return Ok(negocios);
        }

        // GET: api/Negocios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Negocio>> GetNegocio(int id)
        {
            var negocio = await _negocioService.GetNegocioByIdAsync(id);

            if (negocio == null)
            {
                return NotFound();
            }

            return Ok(negocio);
        }

        // POST: api/Negocios
        [HttpPost]
        public async Task<ActionResult<Negocio>> CreateNegocio([FromBody] Negocio negocio)
        {
            // Asegurarse de que el Id no se establece manualmente
            negocio.Id = 0;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Opcional: Validar que las claves foráneas existen
            // Puedes agregar validaciones similares a las que hicimos en PersonasController

            var nuevoNegocio = await _negocioService.CreateNegocioAsync(negocio);
            return CreatedAtAction(nameof(GetNegocio), new { id = nuevoNegocio.Id }, nuevoNegocio);
        }

        // PUT: api/Negocios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNegocio(int id, [FromBody] Negocio negocio)
        {
            if (id != negocio.Id)
            {
                return BadRequest("El ID proporcionado no coincide con el del negocio.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var negocioExistente = await _negocioService.GetNegocioByIdAsync(id);
            if (negocioExistente == null)
            {
                return NotFound();
            }

            await _negocioService.UpdateNegocioAsync(negocio);
            return NoContent();
        }

        // DELETE: api/Negocios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNegocio(int id)
        {
            var negocioExistente = await _negocioService.GetNegocioByIdAsync(id);
            if (negocioExistente == null)
            {
                return NotFound();
            }

            await _negocioService.DeleteNegocioAsync(id);
            return NoContent();
        }
    }
}
