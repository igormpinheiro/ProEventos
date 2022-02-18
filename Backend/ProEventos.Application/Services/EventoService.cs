using AutoMapper;
using ProEventos.Application.DTOs;
using ProEventos.Application.Interfaces;
using ProEventos.Domain.Models;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Application.Services
{
    public class EventoService : IEventoService
    {
        private readonly IEventoPersist persist;
        private readonly IMapper _mapper;

        public EventoService(IEventoPersist eventoPersist,
                             IMapper mapper)
        {
            this.persist = eventoPersist;
        }

        public async Task<EventoDTO> AddEvento(EventoDTO model)
        {
            try
            {
                var evento = _mapper.Map<Evento>(model);

                persist.Add<Evento>(evento);

                if (await persist.SaveChangesAsync())
                {
                    var eventoRetorno = await persist.GetEventoByIdAsync(evento.Id, false);

                    return _mapper.Map<EventoDTO>(eventoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<EventoDTO> UpdateEvento(int eventoId, EventoDTO model)
        {
            try
            {
                var evento = await persist.GetEventoByIdAsync(eventoId, false);
                if (evento == null) return null;

                model.Id = evento.Id;

                _mapper.Map(model, evento);

                persist.Update<Evento>(evento);

                if (await persist.SaveChangesAsync())
                {
                    var eventoRetorno = await persist.GetEventoByIdAsync(evento.Id, false);

                    return _mapper.Map<EventoDTO>(eventoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await persist.GetEventoByIdAsync(eventoId, false);
                if (evento == null) throw new Exception("Evento para delete não encontrado.");

                persist.Delete<Evento>(evento);
                return await persist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<EventoDTO>> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await persist.GetAllEventosAsync(includePalestrantes);
                if (eventos == null) return null;

                var resultado = _mapper.Map<List<EventoDTO>>(eventos);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDTO> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var evento = await persist.GetEventoByIdAsync(eventoId, includePalestrantes);
                if (evento == null) return null;

                var resultado = _mapper.Map<EventoDTO>(evento);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
