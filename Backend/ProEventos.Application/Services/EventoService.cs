using ProEventos.Application.Interfaces;
using ProEventos.Domain.Models;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Application.Services
{
    public class EventoService : IEventoService
    {
        private readonly IEventoPersist persist;

        public EventoService(IEventoPersist eventoPersist)
        {
            this.persist = eventoPersist;
        }

        public async Task<Evento> AddEvento(Evento evento)
        {
            try
            {
                persist.Add<Evento>(evento);
                if (await persist.SaveChangesAsync())
                {
                    return await persist.GetEventoByIdAsync(evento.Id);
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Evento> UpdateEvento(int eventoId, Evento evento)
        {
            try
            {
                var model = await persist.GetEventoByIdAsync(eventoId, false);
                if(model == null) 
                    return null;

                model.Id = eventoId;

                persist.Update<Evento>(evento);
                if (await persist.SaveChangesAsync())
                {
                    return await persist.GetEventoByIdAsync(evento.Id);
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await persist.GetEventoByIdAsync(eventoId, false);
                if (evento == null)
                    return false;

                evento.Id = eventoId;

                persist.Delete<Evento>(evento);
                if (await persist.SaveChangesAsync())
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Evento>> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                return await persist.GetAllEventosAsync(includePalestrantes);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                return await persist.GetEventoByIdAsync(eventoId, includePalestrantes);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
