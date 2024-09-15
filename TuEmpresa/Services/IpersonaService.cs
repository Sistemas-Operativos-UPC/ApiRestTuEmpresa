using TuEmpresa.Model;

namespace TuEmpresa.Services
{
    public interface IpersonaService
    {
        Task<IEnumerable<Persona>> GetAllPersonasAsync();
        Task<Persona> GetPersonaByIdAsync(int id);
        Task<Persona> CreatePersonaAsync(Persona persona);
        Task UpdatePersonaAsync(Persona persona);
        Task DeletePersonaAsync(int id);
    }
}
