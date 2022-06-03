using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Models;

namespace UsuariosApi
{
    public class LogoutService : ILogoutService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LogoutService(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public Result Deslogar()
        {
            var result = _signInManager.SignOutAsync();
            if (result.IsCompletedSuccessfully) return Result.Ok();
            return Result.Fail("logout falhou");
        }
    }
}