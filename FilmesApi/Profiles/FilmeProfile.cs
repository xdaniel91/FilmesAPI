using AutoMapper;
using FilmesApi.Data.DTO;
using FilmesApi.Models;

namespace FilmesApi.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<FilmeDTO, Filme>();
            CreateMap<Filme, FilmeDTO>();
        }
    }
}