using Microsoft.AspNetCore.Identity;
using System;

namespace UsuariosApi.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public DateTime DataNascimento { get; set; }
    }
}
