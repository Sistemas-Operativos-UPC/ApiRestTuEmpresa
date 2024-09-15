using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TuEmpresa.Data;
using TuEmpresa.Model;

namespace TuEmpresa.Services
{
    public class PersonaService : IpersonaService
    {
        private readonly DataContext _context;

        public PersonaService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Persona>> GetAllPersonasAsync()
        {
            return await _context.Personas
                .Include(p => p.TipoDocumento)
                .Include(p => p.TipoPersona)
                .Include(p => p.Departamento)
                .Include(p => p.Provincia)
                .Include(p => p.Distrito)
                .ToListAsync();
        }

        public async Task<Persona> GetPersonaByIdAsync(int id)
        {
            return await _context.Personas
                .Include(p => p.TipoDocumento)
                .Include(p => p.TipoPersona)
                .Include(p => p.Departamento)
                .Include(p => p.Provincia)
                .Include(p => p.Distrito)
                .FirstAsync(p => p.Id == id);
        }

        public async Task<Persona> CreatePersonaAsync(Persona persona)
        {
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();
            return persona;
        }

        public async Task UpdatePersonaAsync(Persona persona)
        {
            _context.Entry(persona).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePersonaAsync(int id)
        {
            var persona = await _context.Personas.FindAsync(id);
            if (persona != null)
            {
                _context.Personas.Remove(persona);
                await _context.SaveChangesAsync();
            }
        }
    }
}
