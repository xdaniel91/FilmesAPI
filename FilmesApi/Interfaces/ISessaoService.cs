using FilmesApi.Data.DTO;
using FilmesApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmesApi.Interfaces
{
    public interface ISessaoService
    {
        public Task AddAsync(Sessao sessao);

        public Task<SessaoDTO> GetByIdAsync(int id);

        public Task<List<SessaoDTO>> GetAll();

        public void Delete(SessaoDTO sessao);

        public Task DeleteByIdAsync(int id);

        public void Update(SessaoDTO sessao);
    }
}