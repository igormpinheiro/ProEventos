using ProEventos.Domain.Models;

namespace ProEventos.Persistence.Interfaces
{
    internal interface IPalestrantePersist
    {
        Task<List<Palestrante>> GetAllPalestrantesAsync(bool includeEventos = false);
        Task<Palestrante> GetPalestranteByUserIdAsync(int userId, bool includeEventos = false);
    }
}
