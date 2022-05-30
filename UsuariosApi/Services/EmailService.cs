using FluentResults;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System.Threading.Tasks;
using UsuariosApi.Data.Dto;
using UsuariosApi.Interfaces;

namespace UsuariosApi.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public Result EnviarEmail(string[] destinatarios, string assunto, int userId, string code)
        {
            var mensagem = new Mensagem(destinatarios, assunto, userId, code);
            var mensagemEmail = CriarEmail(mensagem);
        }

        private static MimeMessage CriarEmail(Mensagem mensagem)
        {
            var mensagemEmail = new MimeMessage();
            mensagemEmail.From.Add(new MailboxAddress("Tss", "daniel.rodrigues@timesharesolucoes.com.br"));
            mensagemEmail.To.AddRange(mensagem.Destinatario);
            mensagemEmail.Subject = mensagem.Assunto;
            mensagemEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = mensagem.Conteudo
            };
            return mensagemEmail;
        }

        private static async Task EnviarAsync(MimeMessage mimeMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect("@@");
                    await client.SendAsync(mimeMessage);
                }
                catch (System.Exception) { throw; }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }
    }
}
