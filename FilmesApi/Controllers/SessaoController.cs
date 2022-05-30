using AutoMapper;
using FilmesApi.Data.DTO;
using FilmesApi.Interfaces;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FilmesApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SessaoController : ControllerBase
    {
        private readonly ISessaoService _sessaoService;
        private readonly IMapper _mapper;

        public SessaoController(ISessaoService sessaoService, IMapper mapper)
        {
            _mapper = mapper;
            _sessaoService = sessaoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var sessoes = await _sessaoService.GetAll();
            return Ok(sessoes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var sessaoDto = await _sessaoService.GetByIdAsync(id);
            return Ok(sessaoDto);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SessaoDTO sessaoDto)
        {
            var sessao = _mapper.Map<Sessao>(sessaoDto);
            await _sessaoService.AddAsync(sessao);
            return Ok(sessao);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] SessaoDTO sessaoDto)
        {
            sessaoDto.Id = id;
            _sessaoService.Update(sessaoDto);
            return Ok(sessaoDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _sessaoService.DeleteByIdAsync(id);
            return NoContent();
        }
    }
}