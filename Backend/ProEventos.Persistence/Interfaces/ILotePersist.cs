using ProEventos.Domain.Models;

namespace ProEventos.Persistence.Interfaces
{
    public interface ILotePersist
    {
        Task<Lote[]> GetLotesByEventoIdAsync(int eventoId);

        Task<Lote> GetLoteByIdsAsync(int eventoId, int id);
    }
}
