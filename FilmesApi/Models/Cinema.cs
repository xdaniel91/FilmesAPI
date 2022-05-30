﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesApi.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public virtual Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }
        public virtual Gerente Gerente { get; set; }
        public int GerenteId { get; set; }

        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }
    }
}