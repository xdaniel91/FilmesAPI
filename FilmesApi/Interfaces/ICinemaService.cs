using FilmesApi.Data.DTO;

namespace FilmesApi.Interfaces
{
    public interface ICinemaService
    {
        public void Add(CinemaDTO cinema);
        public void Remove(CinemaDTO cinema);
        public void Update(CinemaDTO cinema);
        public Task<CinemaDTO> GetByIdAsync(int id);
        public Task<List<CinemaDTO>> GetAllAsync();
        public void DeleteById(int id);
    }
}
