using Microsoft.AspNetCore.Identity;
using UsuariosApi.Models;

namespace UsuariosApi.Interfaces
{
    public interface ITokenService
    {
        public Token CreateToken(IdentityUser<int> identityUser, string role);
    }
}
