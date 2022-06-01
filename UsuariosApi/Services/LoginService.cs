using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using UsuariosApi.Interfaces;
using UsuariosApi.Requests;

namespace UsuariosApi.Services
{
    public class LoginService : ILoginService
    {
        private readonly SignInManager<IdentityUser<int>> _signManager;
        private readonly ITokenService _tokenService;
        public LoginService(SignInManager<IdentityUser<int>> signManager, ITokenService tokenService)
        {
            _signManager = signManager;
            _tokenService = tokenService;
        }

        public async Task<Result> LoginUsuarioAsync(LoginRequest request)
        {
            var result = await _signManager.PasswordSignInAsync(request.Username, request.Senha, false, false);
            if (result.Succeeded)
            {
                var identityUser = await _signManager
                    .UserManager
                    .Users
                    .FirstOrDefaultAsync(
                    user => user.NormalizedUserName == request.Username.ToUpper());

                var roles = await _signManager
                    .UserManager
                    .GetRolesAsync(identityUser);

                var userRole = roles.FirstOrDefault();

                var token = _tokenService.CreateToken(identityUser, userRole);

                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("não foi possivel fazer login");
        }

        public async Task<Result> SolicitaResetSenha(ResetSenhaRequest request)
        {
            var user = await _signManager
                .UserManager
                .Users
                .FirstOrDefaultAsync(
                user => user.NormalizedEmail == request.NormalizedEmail ||
                user.NormalizedEmail == request.Email.ToUpper() ||
                user.Email == request.Email);

            if (user != null)
            {
                var tokenReset = await _signManager.UserManager.GeneratePasswordResetTokenAsync(user);
                return Result.Ok().WithSuccess(tokenReset);
            }

            return Result.Fail("falha ao buscar usuario");
        }

        public async Task<Result> EfetuaReset(EfetuaResetRequest request)
        {
            var user = await _signManager
                .UserManager
                .Users
                .FirstOrDefaultAsync(user => user.NormalizedEmail == request.Email.ToUpper() || user.Email == request.Email);
            if (user != null)
            {
                var token = request.Token;
                var newPassword = request.Senha;
                var result = await _signManager.UserManager.ResetPasswordAsync(user, token, newPassword);
                if (result.Succeeded) return Result.Ok().WithSuccess("senha redefinida com sucesso");
            }
            return Result.Fail("erro ao resetar senha");
        }
    }
}