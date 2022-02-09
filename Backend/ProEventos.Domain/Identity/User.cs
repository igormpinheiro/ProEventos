using Microsoft.AspNetCore.Identity;
using ProEventos.Domain.Enums;

namespace ProEventos.Domain.Identity;

public class User : IdentityUser<int>
{
    public string PrimeiroNome { get; set; }
    public string UltimoNome { get; set; }
    public ETitulo Titulo { get; set; }
    public string Descricao { get; set; }
    public EFuncao Funcao { get; set; }
    public string ImagemURL { get; set; }
    public IEnumerable<UserRole> UserRoles { get; set; }
}