using Microsoft.AspNetCore.Identity;

namespace ProEventos.Domain.Identity;

public class Role : IdentityUserRole<int>
{
    public List<UserRole> UserRoles { get; set; }
}