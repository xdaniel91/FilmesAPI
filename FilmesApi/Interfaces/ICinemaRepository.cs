using FilmesApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmesApi.Interfaces
{
    public interface ICinemaRepository
    {
        public Task AddAsync(Cinema cinema);

        public void Remove(Cinema cinema);

        public void Update(Cinema cinema);

        public Task<Cinema> GetByIdAsync(int id);

        public Task<IEnumerable<Cinema>> GetAllAsync();

        public Task DeleteByIdAsync(int id);
    }
}