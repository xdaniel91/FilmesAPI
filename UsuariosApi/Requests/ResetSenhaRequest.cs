namespace UsuariosApi.Requests
{
    public class ResetSenhaRequest
    {
        public string Username { get; set; }
        public string Senha { get; set; }
        public string NormalizedEmail { get; set; }
        public string Email { get; set; }
    }
}
