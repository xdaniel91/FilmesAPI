namespace UsuariosApi.Dto
{
    public class UsuarioDTO
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ReSenha { get; set; }
        public bool SenhaConfirmada { get; set; }
    }
}