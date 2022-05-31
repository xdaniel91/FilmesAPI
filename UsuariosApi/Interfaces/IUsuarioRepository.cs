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

        public IdentityResult ConfirmEmail(IdentityUser<int> user, string codigoAtivacao);

        public Task<IdentityUser<int>> GetAny();
        public Task<IdentityUser<int>>GetByEmail(string email);
    }
}