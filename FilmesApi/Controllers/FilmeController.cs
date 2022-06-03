using AutoMapper;
using FilmesApi.Data.DTO;
using FilmesApi.Interfaces;
using FilmesApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeService _filmeService;
        private readonly IMapper _mapper;

        public FilmeController(IFilmeService service, IMapper mapper)
        {
            _filmeService = service;
            _mapper = mapper;
        }
      
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] FilmeDTO filmeDto)
        {
            var filme = _mapper.Map<Filme>(filmeDto);
            await _filmeService.AddAsync(filme);
            return Ok(filme);
        }

        [Authorize(Roles = "admin, regular", Policy = "IdadeMinima")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int? classificacao = null)
        {
            if (classificacao == null)
            {
                var filmes = await _filmeService.GetAllAsync();
                return Ok(filmes);
            }
            var filmesClassificacao = await _filmeService.GeyByClassificacao(classificacao);
            if (filmesClassificacao.Count > 0) return Ok(filmesClassificacao);
            return NotFound();
        }

        [Authorize(Roles = "admin, regular")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var filme = _filmeService.GetByIdAsync(id);
            if (filme != null) return Ok(filme);
            return NotFound();
        }

        [Authorize(Roles = "admin, regular")]
        [HttpPatch("{id}")]
        public IActionResult Update(int id, [FromBody] FilmeDTO filmeDto)
        {
            var filme = _filmeService.GetByIdAsync(id);
            filmeDto.Id = filme.Id;
            _filmeService.Update(filmeDto);
            return Ok(filme);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _filmeService.DeleteById(id);
            return Ok();
        }
    }
}