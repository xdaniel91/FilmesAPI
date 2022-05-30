using FilmesApi.Models;
using System.Text.Json.Serialization;

namespace FilmesApi.Data.DTO
{
    public class EnderecoDTO
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }

        [JsonIgnore]
        public Cinema Cinema { get; set; }
    }
}