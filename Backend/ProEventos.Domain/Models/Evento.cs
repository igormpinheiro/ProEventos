namespace ProEventos.Domain.Models;

public class Evento
{
    public int Id { get; private set; }
    public string Local { get; private set; }
    public DateTime? Data { get; private set; }
    public string Tema { get; private set; }
    public int QtdPessoas { get; private set; }
    public IEnumerable<Lote> Lotes { get; private set; }
    public IEnumerable<RedeSocial> RedesSociais { get; private set; }
    public IEnumerable<Palestrante> Palestrantes { get; private set; }
    public string ImagemURL { get; private set; }
}

