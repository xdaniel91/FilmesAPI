using FilmesApi.Data.FilmeContext;
using FilmesApi.Interfaces;
using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmesApi.Repositorios
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<Endereco> _enderecos;

        public EnderecoRepository(ApplicationContext context)
        {
            _context = context;
            _enderecos = _context.enderecos;
        }

        public async Task AddAsync(Endereco endereco)
        {
            _ = await _enderecos.AddAsync(endereco);
            _context.SaveChanges();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var endereco = await _enderecos.FirstOrDefaultAsync(end => end.Id == id);
            _enderecos.Remove(endereco);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Endereco>> GetAllAsync()
        {
            var enderecos = await _enderecos.ToListAsync();
            return enderecos;
        }

        public async Task<Endereco> GetByIdAsync(int id)
        {
            var endereco = await _enderecos.FirstOrDefaultAsync(end => end.Id == id);
            return endereco;
        }

        public void Remove(Endereco endereco)
        {
            _enderecos.Remove(endereco);
            _context.SaveChanges();
        }

        public void Update(Endereco endereco)
        {
            _enderecos.Update(endereco);
            _context.SaveChanges();
        }
    }
}