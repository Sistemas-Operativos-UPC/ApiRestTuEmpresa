using TuEmpresa.Model;

namespace TuEmpresa.Services
{
    public interface INegocioService
    {
        Task<IEnumerable<Negocio>> GetAllNegociosAsync();
        Task<Negocio> GetNegocioByIdAsync(int id);
        Task<Negocio> CreateNegocioAsync(Negocio negocio);
        Task UpdateNegocioAsync(Negocio negocio);
        Task DeleteNegocioAsync(int id);
    }
}
