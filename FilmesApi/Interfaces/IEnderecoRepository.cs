using FilmesApi.Models;

namespace FilmesApi.Interfaces
{
    public interface IEnderecoRepository
    {
        public Task AddAsync(Endereco endereco);

        public void Remove(Endereco endereco);

        public void Update(Endereco endereco);

        public Task<Endereco> GetByIdAsync(int id);

        public Task<IEnumerable<Endereco>> GetAllAsync();

        public Task DeleteByIdAsync(int id);
    }
}