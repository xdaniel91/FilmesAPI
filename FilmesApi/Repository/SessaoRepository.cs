using FilmesApi.Data.FilmeContext;
using FilmesApi.Interfaces;
using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Repositorios
{
    public class SessaoRepository : ISessaoRepository
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<Sessao> _sessoes;

        public SessaoRepository(ApplicationContext context)
        {
            _context = context;
            _sessoes = context.sessoes;
        }

        public async Task AddAsync(Sessao sessao)
        {
            await _sessoes.AddAsync(sessao);
            await _context.SaveChangesAsync();
        }

        public void Delete(Sessao sessao)
        {
            _sessoes.Remove(sessao);
            _context.SaveChanges();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var sessao = await _sessoes.FirstOrDefaultAsync(sessao => sessao.Id == id);
            _sessoes.Remove(sessao);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Sessao>> GetAll()
        {
            var sessoes = await _sessoes.ToListAsync();
            return sessoes;
        }

        public async Task<Sessao> GetByIdAsync(int id)
        {
            var sessao = await _sessoes.FirstOrDefaultAsync(sessao => sessao.Id == id);
            return sessao;
        }

        public void Update(Sessao sessao)
        {
            _sessoes.Update(sessao);
            _context.SaveChanges();
        }
    }
}
