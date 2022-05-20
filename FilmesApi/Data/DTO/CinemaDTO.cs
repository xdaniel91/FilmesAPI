using FilmesApi.Models;
using System.Text.Json.Serialization;

namespace FilmesApi.Data.DTO
{
    public class CinemaDTO
    {
        public  int Id { get; set; }
        public  string Nome{ get; set; }
        public  int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}