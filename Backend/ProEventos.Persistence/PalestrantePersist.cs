using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Models;
using ProEventos.Persistence.Context;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Persistence
{
    public class PalestrantePersist : BasePersist, IPalestrantePersist
    {
        private readonly DataContext _context;
        public PalestrantePersist(DataContext context) : base(context)
        {
            _context = context;
        }

        public Task<List<Palestrante>> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedesSociais);

            if (includeEventos)
            {
                query = query.Include(p => p.Eventos);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return query.ToListAsync();
        }

        public Task<Palestrante> GetPalestranteByUserIdAsync(int userId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedesSociais);

            if (includeEventos)
            {
                query = query.Include(p => p.Eventos);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return query.FirstOrDefaultAsync();
        }
    }
}
