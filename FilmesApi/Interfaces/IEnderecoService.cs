using FilmesApi.Data.DTO;
using FilmesApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmesApi.Interfaces
{
    public interface IEnderecoService
    {
        public void Add(Endereco endereco);

        public void Remove(EnderecoDTO enderecoDto);

        public void Update(EnderecoDTO enderecoDto);

        public Task<EnderecoDTO> GetByIdAsync(int id);

        public Task<List<EnderecoDTO>> GetAll();

        public void DeleteById(int id);
    }
}