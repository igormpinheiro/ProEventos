namespace ProEventos.Domain.Models;

public class Palestrante
{
    public int Id { get; set; }
    public string MiniCurriculo { get; set; }
    public int UserId { get; set; }
    public IEnumerable<RedeSocial> RedesSociais { get; set; }
    public IEnumerable<Evento> Eventos { get; set; }
}