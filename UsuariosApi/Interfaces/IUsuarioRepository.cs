using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using UsuariosApi.Models;

namespace UsuariosApi.Interfaces
{
    public interface IUsuarioRepository
    {
        public Task<Result> CreateAsync(ApplicationUser identityUser, string senha);

        public Task<string> GerarTokenConfirmacaoEmail(ApplicationUser identityUser);

        public Task<ApplicationUser> GetUser(int id);

        public IdentityResult ConfirmEmail(ApplicationUser user, string codigoAtivacao);

        public Task<ApplicationUser> GetAny();
        public Task<ApplicationUser>GetByEmail(string email);
    }
}