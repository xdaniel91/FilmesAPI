using FilmesApi.Data.DTO;
using FilmesApi.Models;

namespace FilmesApi.Interfaces
{
    public interface IEnderecoService
    {
        public void Add(EnderecoDTO endereco);
        public void Remove(EnderecoDTO endereco);
        public void Update(EnderecoDTO endereco);
        public Task<EnderecoDTO> GetByIdAsync(int id);
        public Task<List<EnderecoDTO>> GetAll();
        public void DeleteById(int id);
    }
}
