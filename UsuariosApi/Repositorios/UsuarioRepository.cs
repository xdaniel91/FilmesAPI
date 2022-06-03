using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UsuariosApi.Interfaces;
using UsuariosApi.Models;

namespace UsuariosApi.Repositorios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public UsuarioRepository(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IdentityResult ConfirmEmail(ApplicationUser user, string codigoAtivacao)
        {
            var result = _userManager.ConfirmEmailAsync(user, codigoAtivacao).Result;
            return result;
        }

        public async Task<Result> CreateAsync(ApplicationUser identityUser, string senha)
        {
            var createResult = await _userManager.CreateAsync(identityUser, senha);
            var userRoleResult = await _userManager.AddToRoleAsync(identityUser, "regular");
            if (createResult.Succeeded && userRoleResult.Succeeded) return Result.Ok();
            return Result.Fail("falha ao criar usuario");
        }

        public async Task<string> GerarTokenConfirmacaoEmail(ApplicationUser identityUser)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(identityUser);
            return code;
        }

        public async Task<ApplicationUser> GetUser(int id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<ApplicationUser> GetAny()
        {
            var user = await _userManager.Users.FirstAsync();
            return user;
        }

        public async Task<ApplicationUser> GetByEmail(string email)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(user => user.Email == email);
            return user;
        }
    }
}