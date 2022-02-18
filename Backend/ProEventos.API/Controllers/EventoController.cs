using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.Interfaces;
using ProEventos.Domain.Models;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{
    private readonly IEventoService service;

    public EventoController(IEventoService service)
    {
        this.service = service;
    }


    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var eventos = await service.GetAllEventosAsync(true);
            if(eventos == null)
            {
                return NotFound("Nenhum evento encontrado");
            }
            return Ok(eventos);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar recuperar os eventos. Erro: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EventoDTO>> GetById(int id)
    {
        try
        {
            var evento = await service.GetEventoByIdAsync(id, true);
            if (evento == null) return NoContent();

            return Ok(evento);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
        }
    }

    //[HttpPost("upload-image/{eventoId}")]
    //public async Task<IActionResult> UploadImage(int eventoId)
    //{
    //    try
    //    {
    //        var evento = await service.GetEventoByIdAsync(User.GetUserId(), eventoId, true);
    //        if (evento == null) return NoContent();

    //        var file = Request.Form.Files[0];
    //        if (file.Length > 0)
    //        {
    //            _util.DeleteImage(evento.ImagemURL, _destino);
    //            evento.ImagemURL = await _util.SaveImage(file, _destino);
    //        }
    //        var EventoRetorno = await service.UpdateEvento(User.GetUserId(), eventoId, evento);

    //        return Ok(EventoRetorno);
    //    }
    //    catch (Exception ex)
    //    {
    //        return this.StatusCode(StatusCodes.Status500InternalServerError,
    //            $"Erro ao tentar realizar upload de foto do evento. Erro: {ex.Message}");
    //    }
    //}

    //[HttpPost]
    //public async Task<IActionResult> Post(EventoDto model)
    //{
    //    try
    //    {
    //        var evento = await service.AddEventos(User.GetUserId(), model);
    //        if (evento == null) return NoContent();

    //        return Ok(evento);
    //    }
    //    catch (Exception ex)
    //    {
    //        return this.StatusCode(StatusCodes.Status500InternalServerError,
    //            $"Erro ao tentar adicionar eventos. Erro: {ex.Message}");
    //    }
    //}

    //[HttpPut("{id}")]
    //public async Task<IActionResult> Put(int id, EventoDto model)
    //{
    //    try
    //    {
    //        var evento = await service.UpdateEvento(User.GetUserId(), id, model);
    //        if (evento == null) return NoContent();

    //        return Ok(evento);
    //    }
    //    catch (Exception ex)
    //    {
    //        return this.StatusCode(StatusCodes.Status500InternalServerError,
    //            $"Erro ao tentar atualizar eventos. Erro: {ex.Message}");
    //    }
    //}

    //[HttpDelete("{id}")]
    //public async Task<IActionResult> Delete(int id)
    //{
    //    try
    //    {
    //        var evento = await service.GetEventoByIdAsync(User.GetUserId(), id, true);
    //        if (evento == null) return NoContent();

    //        if (await service.DeleteEvento(User.GetUserId(), id))
    //        {
    //            _util.DeleteImage(evento.ImagemURL, _destino);
    //            return Ok(new { message = "Deletado" });
    //        }
    //        else
    //        {
    //            throw new Exception("Ocorreu um problem não específico ao tentar deletar Evento.");
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        return this.StatusCode(StatusCodes.Status500InternalServerError,
    //            $"Erro ao tentar deletar eventos. Erro: {ex.Message}");
    //    }
    //}
}