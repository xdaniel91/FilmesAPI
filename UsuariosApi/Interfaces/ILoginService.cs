using FluentResults;
using System.Threading.Tasks;
using UsuariosApi.Services;

namespace UsuariosApi.Interfaces
{
    public interface ILoginService
    {
        public Task<Result> LoginUsuarioAsync(LoginRequest request);
    }
}