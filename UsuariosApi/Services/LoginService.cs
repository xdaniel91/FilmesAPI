using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using UsuariosApi.Interfaces;
using UsuariosApi.Requests;

namespace UsuariosApi.Services
{
    public class LoginService : ILoginService
    {
        private readonly SignInManager<IdentityUser<int>> _signManager;
        public LoginService(SignInManager<IdentityUser<int>> signManager)
        {
            _signManager = signManager;
        }

        public async Task<Result> LoginUsuarioAsync(LoginRequest request)
        {
            var result = await _signManager.PasswordSignInAsync(request.Username, request.Senha, false, false);
            if (result.Succeeded)

                return Result.Ok();

            return Result.Fail("não foi possivel fazer login");
        }
    }
}