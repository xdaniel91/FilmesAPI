using FilmesApi.Data.DTO;
using FilmesApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmesApi.Interfaces
{
    public interface ICinemaService
    {
        public Task AddAsync(Cinema cinema);

        public void Remove(CinemaDTO cinemaDto);

        public void Update(CinemaDTO cinemaDto);

        public Task<CinemaDTO> GetByIdAsync(int id);

        public Task<List<CinemaDTO>> GetAllAsync();

        public void DeleteById(int id);
    }
}