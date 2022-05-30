using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data.Dto;

namespace UsuariosApi.Interfaces
{
    public interface IEmailService
    {
        public Result EnviarEmail(string[] destinatarios, string assunto, int userId, string code);
    }
}
