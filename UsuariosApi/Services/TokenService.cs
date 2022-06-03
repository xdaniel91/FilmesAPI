using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsuariosApi.Interfaces;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class TokenService : ITokenService
    {
        public Token CreateToken(ApplicationUser identityUser, string role)
        {
            var direitosUsuario = new Claim[]
                {
                    new Claim("username", identityUser.UserName),
                    new Claim("Id", identityUser.Id.ToString()),
                    new Claim(ClaimTypes.Role, role),
                    new Claim(ClaimTypes.DateOfBirth, identityUser.DataNascimento.ToString())
                };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("clMAY6M6a7e3MDmW79RB"));
            var credenciais = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: direitosUsuario,
                signingCredentials: credenciais,
                expires: System.DateTime.UtcNow.AddHours(10));

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            var myToken = new Token(tokenString);
            return myToken;
        }
    }
}