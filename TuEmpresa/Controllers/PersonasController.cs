using Microsoft.AspNetCore.Mvc; 
using System.Collections.Generic;
using System.Threading.Tasks;
using TuEmpresa.Model;
using TuEmpresa.Services;

namespace TuEmpresa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly IpersonaService _personaService;

        public PersonasController(IpersonaService personaService)
        {
            _personaService = personaService;
        }

        // GET: api/Personas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> GetPersonas()
        {
            var personas = await _personaService.GetAllPersonasAsync();
            return Ok(personas);
        }

        // GET: api/Personas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> GetPersona(int id)
        {
            var persona = await _personaService.GetPersonaByIdAsync(id);

            if (persona == null)
            {
                return NotFound();
            }

            return Ok(persona);
        }

        // POST: api/Personas
        [HttpPost]
        public async Task<ActionResult<Persona>> CreatePersona([FromBody] Persona persona)
        {
            // Eliminar el Id para asegurar que se genere automáticamente
            persona.Id = 0;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var nuevaPersona = await _personaService.CreatePersonaAsync(persona);
            return CreatedAtAction(nameof(GetPersona), new { id = nuevaPersona.Id }, nuevaPersona);
        }

        // PUT: api/Personas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePersona(int id,[FromBody] Persona persona)
        {
            if (id != persona.Id)
            {
                return BadRequest();
            }

            //Validar que la persona exista
            var personaExistente = await _personaService.GetPersonaByIdAsync(id);
            if (personaExistente == null)
            {
                return NotFound();
            }

            await _personaService.UpdatePersonaAsync(persona);
            return NoContent();
        }

        // DELETE: api/Personas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersona(int id)
        {
            await _personaService.DeletePersonaAsync(id);
            return NoContent();
        }
    }
}
