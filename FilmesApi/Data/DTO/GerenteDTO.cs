using FilmesApi.Models;
using System.Text.Json.Serialization;

namespace FilmesApi.Data.DTO
{
    public class GerenteDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public object Cinemas { get; set; }
    }
}
