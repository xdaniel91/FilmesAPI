using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Requests
{
    public class EfetuaResetRequest
    {
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [DataType(DataType.Password)]
        [Compare("Senha")]
        public string ReSenha { get; set; }

        public string Email { get; set; }
        [Required]
        public string Token { get; set; }

    }
}
