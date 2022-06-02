using FilmesApi.Models;
using System;

namespace FilmesApi.Data.DTO
{
    public class SessaoDTO
    {
        public int Id { get; set; }
        public virtual Cinema Cinema { get; set; }
        public virtual Filme Filme { get; set; }
        public int FilmeId { get; set; }
        public int CinemaId { get; set; }
        public DateTime HorarioEncerramento { get; set; }
        public DateTime HorarioInicio { get; set; }
    }
}