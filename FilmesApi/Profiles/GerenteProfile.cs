using AutoMapper;
using FilmesApi.Data.DTO;
using FilmesApi.Models;

namespace FilmesApi.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<GerenteDTO, Gerente>();
            CreateMap<Gerente, GerenteDTO>();

        }
    }
}
