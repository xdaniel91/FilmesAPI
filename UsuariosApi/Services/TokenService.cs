using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class TokenService
    {
        public Token CreateToken(IdentityUser<int> identityUser)
        {
            var direitosUsuario = new Claim[]
                {
                    new Claim("username", identityUser.UserName),
                    new Claim("Id", identityUser.Id.ToString())
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
