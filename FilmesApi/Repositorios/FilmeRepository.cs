using FilmesApi.Data.FilmeContext;
using FilmesApi.Interfaces;
using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Repositorios
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly ApplicationContext _context;

        public FilmeRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Filme filme)
        {
            _ = await _context.filmes.AddAsync(filme);
            _context.SaveChanges();
        }

        public void Delete(Filme filme)
        {
            _context.filmes.Remove(filme);
            _context.SaveChanges();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var filme = await GetByIdAsync(id);
            _context.filmes.Remove(filme);
            _context.SaveChanges();
        }

        public async Task<Filme> GetByIdAsync(int id)
        {
            var result = await _context.filmes.FirstOrDefaultAsync(filme => filme.Id == id);
            return result;
        }

        public async Task<IEnumerable<Filme>> GetAll()
        {
            var filmes = await _context.filmes.ToListAsync();
            return filmes;
        }

        public void Update(Filme filme)
        {
            _context.filmes.Update(filme);
            _context.SaveChanges();
        }
    }
}
