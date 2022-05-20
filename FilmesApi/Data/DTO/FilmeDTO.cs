﻿using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.DTO
{
    public class FilmeDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Diretor is required")]
        public string Diretor { get; set; }

        [Required(ErrorMessage = "Titulo is required")]
        public string Titulo { get; set; }
        public string Genero { get; set; }
        [Range(1, 400)]
        public int DuracaoMinutos { get; set; }
        public DateTime HoraConsulta
        {
            get
            {
                return DateTime.Now;
            }
        }
    }
}
