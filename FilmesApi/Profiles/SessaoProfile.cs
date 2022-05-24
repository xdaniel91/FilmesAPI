using AutoMapper;
using FilmesApi.Data.DTO;
using FilmesApi.Models;

namespace FilmesApi.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<SessaoDTO, Sessao>();
            CreateMap<Sessao, SessaoDTO>();
        }
    }
}
