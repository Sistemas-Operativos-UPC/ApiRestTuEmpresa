using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TuEmpresa.Data;
using TuEmpresa.Model;

namespace TuEmpresa.Services
{
    public class NegocioService : INegocioService
    {
        private readonly DataContext _context;

        public NegocioService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Negocio>> GetAllNegociosAsync()
        {
            return await _context.Negocios
                .Include(n => n.TipoModalidadEmpresarial)
                .Include(n => n.Departamento)
                .Include(n => n.Provincia)
                .Include(n => n.Distrito)
                .Include(n => n.NombresNegocios)
                .ToListAsync();
        }

        public async Task<Negocio> GetNegocioByIdAsync(int id)
        {
            return await _context.Negocios
                .Include(n => n.TipoModalidadEmpresarial)
                .Include(n => n.Departamento)
                .Include(n => n.Provincia)
                .Include(n => n.Distrito)
                .Include(n => n.NombresNegocios)
                .FirstAsync(n => n.Id == id);
        }

        public async Task<Negocio> CreateNegocioAsync(Negocio negocio)
        {
            _context.Negocios.Add(negocio);
            await _context.SaveChangesAsync();
            return negocio;
        }

        public async Task UpdateNegocioAsync(Negocio negocio)
        {
            _context.Entry(negocio).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteNegocioAsync(int id)
        {
            var negocio = await _context.Negocios.FindAsync(id);
            if (negocio != null)
            {
                _context.Negocios.Remove(negocio);
                await _context.SaveChangesAsync();
            }
        }
    }
}
