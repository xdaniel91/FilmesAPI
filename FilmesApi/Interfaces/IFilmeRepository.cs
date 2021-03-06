using FilmesApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmesApi.Interfaces
{
    public interface IFilmeRepository
    {
        public Task AddAsync(Filme filme);

        public void Update(Filme filme);

        public Task<List<Filme>> GetAll();

        public Task<Filme> GetByIdAsync(int id);

        public Task<List<Filme>> GetByClassificacao(int? idade);

        public void Delete(Filme filme);

        public Task DeleteByIdAsync(int id);
    }
}