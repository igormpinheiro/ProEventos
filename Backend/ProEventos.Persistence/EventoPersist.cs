using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Models;
using ProEventos.Persistence.Context;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Persistence
{
    public class EventoPersist : BasePersist, IEventoPersist
    {
        private readonly DataContext _context;
        public EventoPersist(DataContext context) : base(context)
        {
            _context = context;
        }

        public Task<List<Evento>> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais);

            if (includePalestrantes)
            {
                query = query
                    .Include(e => e.Palestrantes);
            }

            query = query.AsNoTracking()
                         .OrderBy(e => e.Id);

            return query.ToListAsync();
        }

        public Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais);

            if (includePalestrantes)
            {
                query = query
                    .Include(e => e.Palestrantes);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id)
                         .Where(e => e.Id == eventoId);

            return query.FirstOrDefaultAsync();
        }
    }
}
