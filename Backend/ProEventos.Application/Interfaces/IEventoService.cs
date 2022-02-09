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
        Task<Evento> AddEvento(Evento evento);
        Task<Evento> UpdateEvento(int eventoId, Evento evento);
        Task<bool> DeleteEvento(int eventoId);
        Task<List<Evento>> GetAllEventosAsync(bool includePalestrantes = false);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false);
    }
}
