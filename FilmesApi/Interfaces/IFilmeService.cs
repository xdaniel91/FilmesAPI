using FilmesApi.Data.DTO;
using FilmesApi.Models;

namespace FilmesApi.Interfaces
{
    public interface IFilmeService
    {
        public Task AddAsync(Filme filme);

        public void Remove(FilmeDTO filme);

        public void Update(FilmeDTO filme);

        public Task<FilmeDTO> GetByIdAsync(int id);

        public Task<List<FilmeDTO>> GeyByClassificacao(int? idade);

        Task<List<FilmeDTO>> GetAllAsync();
        public void DeleteById(int id);
    }
}