using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace FilmesApi.Data.DTO
{
    public class FilmeDTO
    {
        private readonly CultureInfo culture = CultureInfo.CurrentCulture;

        public int Id { get; set; }

        [Required(ErrorMessage = "Diretor is required")]
        public string Diretor { get; set; }

        [Required(ErrorMessage = "Titulo is required")]
        public string Titulo { get; set; }

        public string Genero { get; set; }

        [Range(1, 400)]
        public int DuracaoMinutos { get; set; }

        public int Classificacao { get; set; }

        public string HoraConsulta
        {
            get
            {
                return DateTime.Now.ToString(culture);
            }
        }
    }
}