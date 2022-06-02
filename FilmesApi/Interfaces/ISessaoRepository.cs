using FilmesApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmesApi.Interfaces
{
    public interface ISessaoRepository
    {
        public Task AddAsync(Sessao sessao);

        public Task<Sessao> GetByIdAsync(int id);

        public Task<IEnumerable<Sessao>> GetAll();

        public void Delete(Sessao sessao);

        public Task DeleteByIdAsync(int id);

        public void Update(Sessao sessao);
    }
}