using FilmesApi.Data.DTO;
using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models
{
    public class Filme
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Diretor is required")]
        public string Diretor { get; set; }

        [Required(ErrorMessage = "Titulo is required")]
        public string Titulo { get; set; }
        public string Genero { get; set; }
        [Range(1, 400)]
        public int DuracaoMinutos { get; set; }

        protected Filme()
        {
        }

        public Filme(string diretor, string titulo, string genero, int duracao)
        {
            Diretor = diretor;
            Titulo = titulo;
            Genero = genero;
            DuracaoMinutos = duracao;
        }


        public static implicit operator Filme(FilmeDTO filmeDto)
        {
            return new Filme
            {
                Diretor = filmeDto.Diretor,
                Titulo = filmeDto.Titulo,
                Genero = filmeDto.Genero,
                DuracaoMinutos = filmeDto.DuracaoMinutos
            };
        }

        public static Filme ConvertToDto(FilmeDTO filmeDto)
        {
            return filmeDto;
        }
    }
}