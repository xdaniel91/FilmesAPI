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
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public UsuarioRepository(UserManager<IdentityUser<int>> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IdentityResult ConfirmEmail(IdentityUser<int> user, string codigoAtivacao)
        {
            var result = _userManager.ConfirmEmailAsync(user, codigoAtivacao).Result;
            return result;
        }

        public async Task<Result> CreateAsync(IdentityUser<int> identityUser, string senha)
        {
            var createResult = await _userManager.CreateAsync(identityUser, senha);
            var roleExists = await _roleManager.RoleExistsAsync("admin");
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole<int>("admin"));
            }
            var userRoleResult = await _userManager.AddToRoleAsync(identityUser, "admin");
            if (createResult.Succeeded && userRoleResult.Succeeded) return Result.Ok();
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