using AutoMapper;
using FilmesApi.Data.DTO;
using FilmesApi.Models;

namespace FilmesApi.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CinemaDTO, Cinema>();
            CreateMap<Cinema, CinemaDTO>();
        }
    }
}