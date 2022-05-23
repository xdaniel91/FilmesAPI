using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data.FilmeContext
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Filme> filmes { get; set; }
        public DbSet<Endereco> enderecos { get; set; }
        public DbSet<Cinema> cinemas { get; set; }
        public DbSet<Gerente> gerentes { get; set; }
        public DbSet<Sessao> sessoes { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Endereco>()
                .HasOne(end => end.Cinema)
                .WithOne(cin => cin.Endereco)
                .HasForeignKey<Cinema>(cinema => cinema.EnderecoId);
            /*1:1
             * my entity Endereco have one Cinema
             * my one Cinema have just one Endereco
             * that my foreignkey is in Cinema on EnderecoId property */


            modelBuilder.Entity<Cinema>()
                .HasOne(cin => cin.Gerente)
                .WithMany(ger => ger.Cinemas)
                .HasForeignKey(cin => cin.GerenteId)
                .OnDelete(DeleteBehavior.Restrict);

            /* 1:N
             * my entity cinema
            * have one gerente
            * my one gerente have many cinemas
            * that foreignkey is "gerenteId" inside cinema 
            * on delete restrict */

            modelBuilder.Entity<Sessao>()
                .HasOne(sessao => sessao.Filme)
                .WithMany(filme => filme.Sessoes)
                .HasForeignKey(sessao => sessao.FilmeId);

            modelBuilder.Entity<Sessao>()
                .HasOne(sessao => sessao.Cinema)
                .WithMany(cinema => cinema.Sessoes)
                .HasForeignKey(sessoes => sessoes.CinemaId);

            /* N:N
             * my entity sessao have one filme/cinema
             * my one cinema/filme have many sessions
             * that foreignkey is filme_id/cinema_id inside session class */


        }
    }
}
