using AutoMapper;
using FilmesApi.Data.DTO;
using FilmesApi.Models;
using System.Linq;

namespace FilmesApi.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<GerenteDTO, Gerente>();
            CreateMap<Gerente, GerenteDTO>()
                .ForMember(ger => ger.Cinemas, options => options.MapFrom           // for my property "Cinemas" that is a generic obj inside dto, map this from
                (gerente => gerente.Cinemas.Select                                  // gerente.Cinemas that is a List<Cinema>
                (cin => new { cin.Id, cin.Nome, cin.Endereco, cin.EnderecoId })));  // catch these properties from cinema take in my generic obj "cinemas" in dto
        }
    }
}