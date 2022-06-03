using System;

namespace UsuariosApi.Dto
{
    public class UsuarioDTO
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimeto { get; set; }
    }
}