using FilmesApi.Data.FilmeContext;
using FilmesApi.Interfaces;
using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Repositorios
{
    public class GerenteRepository : IGerenteRepository
    {

        private readonly ApplicationContext _context;
        private readonly DbSet<Gerente> _gerentes;

        public GerenteRepository(ApplicationContext context)
        {
            _context = context;
            _gerentes = context.gerentes;
        }

        public async Task AddAsync(Gerente gerente)
        {
            await _gerentes.AddAsync(gerente);
            _context.SaveChanges();
        }

        public void Delete(Gerente gerente)
        {
            _gerentes.Remove(gerente);
            _context.SaveChanges();
        }

        public async Task DeleteByIdAsync(int id)
        {
            try
            {
                var gerente = await _gerentes.FindAsync(id);
                _gerentes.Remove(gerente);
                _context.SaveChanges();

            }
            catch (Exception) { throw; }
        }

        public async Task<IEnumerable<Gerente>> GetAll()
        {
            var gerentes = await _gerentes.ToListAsync();
            return gerentes;
        }

        public async Task<Gerente> GetByIdAsync(int id)
        {
            var gerente = await _gerentes.FirstOrDefaultAsync(ger => ger.Id == id);
            return gerente;
        }

        public void Update(Gerente gerente)
        {
            _gerentes.Update(gerente);
            _context.SaveChanges();
        }
    }
}
