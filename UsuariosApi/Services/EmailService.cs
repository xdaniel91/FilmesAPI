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

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Result EnviarEmail(string[] destinatarios, string assunto, int userId, string code)
        {
            var mensagem = new Mensagem(destinatarios, assunto, userId, code);
            var mensagemEmail = CriarEmail(mensagem);
            var result = EnviarAsync(mensagemEmail);
            if (result.IsCompletedSuccessfully) return Result.Ok();
            return Result.Fail("falha ao enviar e-mail");

        }

        private  MimeMessage CriarEmail(Mensagem mensagem)
        {
            var mensagemEmail = new MimeMessage();
            var remetente = _configuration.GetValue<string>("EmailSettings:From");

            mensagemEmail.From.Add(new MailboxAddress("Tss", remetente));
            mensagemEmail.To.AddRange(mensagem.Destinatario);
            mensagemEmail.Subject = mensagem.Assunto;
            mensagemEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = mensagem.Conteudo
            };
            return mensagemEmail;
        }

        private async Task EnviarAsync(MimeMessage mimeMessage)
        {
            using var client = new SmtpClient();
            try
            {
                var email = _configuration.GetValue<string>("EmailSettings:From");
                var senha = _configuration.GetValue<string>("EmailSettings:Password");
                var smtpServer = _configuration.GetValue<string>("EmailSettings:SmtpServer");
                var port = _configuration.GetValue<int>("EmailSettings:Port");

                client.Connect(smtpServer, port, true);
                client.AuthenticationMechanisms.Remove("XOUATH2");
                client.Authenticate(email, senha);
                client.Send(mimeMessage);
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
