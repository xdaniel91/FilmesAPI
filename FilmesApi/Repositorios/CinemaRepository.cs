using FilmesApi.Data.FilmeContext;
using FilmesApi.Interfaces;
using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Repositorios
{
    public class CinemaRepository : ICinemaRepository
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<Cinema> _cinemas;

        public CinemaRepository(ApplicationContext context)
        {
            _context = context;
            _cinemas = _context.Cinemas;
        }

        public async Task AddAsync(Cinema cinema)
        {
            _ = await _cinemas.AddAsync(cinema);
            _context.SaveChanges();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var cinema = await _cinemas.FirstOrDefaultAsync(cin => cin.Id == id);
            _cinemas.Remove(cinema);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Cinema>> GetAllAsync()
        {
            var cinemas = await _cinemas.ToListAsync();
            return cinemas;
        }

        public async Task<Cinema> GetByIdAsync(int id)
        {
            var cinema = await _cinemas.FirstOrDefaultAsync(cin => cin.Id == id);
            return cinema;
        }

        public void Remove(Cinema cinema)
        {
            _cinemas.Remove(cinema);
            _context.SaveChanges();
        }

        public void Update(Cinema cinema)
        {
            _cinemas.Update(cinema);
            _context.SaveChanges();
        }
    }
}
