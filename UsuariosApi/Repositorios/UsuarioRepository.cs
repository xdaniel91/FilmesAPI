using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UsuariosApi.Interfaces;

namespace UsuariosApi.Repositorios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UserManager<IdentityUser<int>> _userManager;

        public UsuarioRepository(UserManager<IdentityUser<int>> userManager)
        {
            _userManager = userManager;
        }

        public IdentityResult ConfirmEmail(IdentityUser<int> user, string codigoAtivacao)
        {
            var result = _userManager.ConfirmEmailAsync(user, codigoAtivacao).Result;
            return result;
        }

        public async Task<Result> CreateAsync(IdentityUser<int> identityUser, string senha)
        {
            var result = await _userManager.CreateAsync(identityUser, senha);
            if (result.Succeeded) return Result.Ok();
            return Result.Fail("falha ao criar usuario");
        }

        public async Task<string> GerarTokenConfirmacaoEmail(IdentityUser<int> identityUser)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(identityUser);
            return code;
        }

        public async Task<IdentityUser<int>> GetUser(int id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<IdentityUser<int>> GetAny()
        {
            var user = await _userManager.Users.FirstAsync();
            return user;
        }

        public async Task<IdentityUser<int>> GetByEmail(string email)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(user => user.Email == email);
            return user;
        }
    }
}