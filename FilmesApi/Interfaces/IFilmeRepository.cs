using FilmesApi.Models;

namespace FilmesApi.Interfaces
{
    public interface IFilmeRepository
    {
        public Task AddAsync(Filme filme);
        public void Update(Filme filme);
        public Task<IEnumerable<Filme>> GetAll();
        public Task<Filme> GetByIdAsync(int id);
        public void Delete(Filme filme);
        public Task DeleteByIdAsync(int id);
    }
}
