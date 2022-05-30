using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace UsuariosApi.Interfaces
{
    public interface IUsuarioRepository
    {
        public Task<Result> CreateAsync(IdentityUser<int> identityUser, string senha);

        public Task<string> GerarTokenConfirmacaoEmail(IdentityUser<int> identityUser);

        public Task<IdentityUser<int>> GetUser(int id);

        public Task<IdentityResult> ConfirmEmailAsync(IdentityUser<int> user, string codigoAtivacao);
    }
}