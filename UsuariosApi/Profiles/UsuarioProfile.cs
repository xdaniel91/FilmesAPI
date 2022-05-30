using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Dto;
using UsuariosApi.Models;

namespace UsuariosApi.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<UsuarioDTO, Usuario>();
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<Usuario, IdentityUser<int>>();
            CreateMap<IdentityUser<int>, Usuario>();
        }
    }
}