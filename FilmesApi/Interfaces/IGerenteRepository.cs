using FilmesApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmesApi.Interfaces
{
    public interface IGerenteRepository
    {
        public Task AddAsync(Gerente gerente);

        public Task<Gerente> GetByIdAsync(int id);

        public Task<IEnumerable<Gerente>> GetAll();

        public void Delete(Gerente gerente);

        public Task DeleteByIdAsync(int id);

        public void Update(Gerente gerente);
    }
}