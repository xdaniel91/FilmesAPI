using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data.FilmeContext
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Gerente> Gerentes { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Endereco>()
                .HasOne(end => end.Cinema)
                .WithOne(cin => cin.Endereco)
                .HasForeignKey<Cinema>(cinema => cinema.EnderecoId);
        }
    }
}
