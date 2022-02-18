using ProEventos.Application.DTOs;
using ProEventos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Application.Interfaces
{
    public interface IEventoService
    {
        Task<EventoDTO> AddEvento(EventoDTO evento);
        Task<EventoDTO> UpdateEvento(int eventoId, EventoDTO evento);
        Task<bool> DeleteEvento(int eventoId);

        Task<List<EventoDTO>> GetAllEventosAsync(bool includePalestrantes = false);
        Task<EventoDTO> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false);
    }
}
