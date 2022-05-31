using MimeKit;
using System.Collections.Generic;
using System.Linq;

namespace UsuariosApi.Data.Dto
{
    public class Mensagem
    {
        public List<MailboxAddress> Destinatario { get; set; }
        public string Assunto { get; set; }
        public string Conteudo { get; set; }

        public Mensagem(IEnumerable<string> destinatarios, string assunto, int userId, string codigoAtivacao)
        {
            Destinatario = new List<MailboxAddress>();
            Destinatario.AddRange(destinatarios.Select(d => new MailboxAddress(d, d))) ;
            Assunto = assunto;
            Conteudo = $"https://localhost:44303/ativacao?UsuarioId={userId}&CodigoAtivacao={codigoAtivacao}";

        }

    }
}
