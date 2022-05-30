using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using UsuariosApi.Interfaces;

namespace UsuariosApi.Services
{
    public class LoginService : ILoginService
    {
        private SignInManager<IdentityUser<int>> _signManager;
        private TokenService _tokenService;

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