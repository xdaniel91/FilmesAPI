using FluentResults;
using System.Threading.Tasks;
using UsuariosApi.Requests;

namespace UsuariosApi.Interfaces
{
    public interface ILoginService
    {
        public Task<Result> LoginUsuarioAsync(LoginRequest request);
        public Task<Result> SolicitaResetSenha(ResetSenhaRequest request);
    }
}