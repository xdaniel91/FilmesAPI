using FilmesApi.Models;
using System.Collections.Generic;

namespace FilmesApi.Data.DTO
{
    public class CinemaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual Gerente Gerente { get; set; }
        public int GerenteId { get; set; }
        public virtual List<Sessao> Sessoes { get; set; }
    }
}