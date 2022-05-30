using AutoMapper;
using FilmesApi.Data.DTO;
using FilmesApi.Interfaces;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICinemaService _cinemaService;

        public CinemaController(ICinemaService cinemaService, IMapper mapper)
        {
            _mapper = mapper;
            _cinemaService = cinemaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] string nomeFilme)
        {
            var cinemas = await _cinemaService.GetAllAsync();
            if (cinemas == null) return NotFound();
            if (!string.IsNullOrEmpty(nomeFilme))
            {
                var query = from cinema in cinemas
                            where cinema.Sessoes.Any(sessao => sessao.Filme.Titulo == nomeFilme)
                            select cinema;
                cinemas = query.ToList();
            }
            return Ok(cinemas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var cinema = await _cinemaService.GetByIdAsync(id);
            if (cinema == null) return NotFound();
            var cinemaDto = _mapper.Map<CinemaDTO>(cinema);
            return Ok(cinemaDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CinemaDTO cinemaDto)
        {
            var cinema = _mapper.Map<Cinema>(cinemaDto);
            await _cinemaService.AddAsync(cinema);
            return Ok(cinema);

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CinemaDTO cinemaDto)
        {
            cinemaDto.Id = id;
            _cinemaService.Update(cinemaDto);
            return Ok(cinemaDto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _cinemaService.DeleteById(id);
            return Ok();
        }
    }
}
