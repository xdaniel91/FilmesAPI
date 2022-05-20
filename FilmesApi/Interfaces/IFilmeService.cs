using FilmesApi.Data.DTO;
using FilmesApi.Models;

namespace FilmesApi.Interfaces
{
    public interface IFilmeService
    {
        public Task AddAsync(FilmeDTO filme);
        public void Remove(FilmeDTO filme);
        public void Update(FilmeDTO filme);
        public Task<FilmeDTO> GetByIdAsync(int id);
        public Task<List<FilmeDTO>> GetAllAsync();
        public void DeleteById(int id);
    }
}
