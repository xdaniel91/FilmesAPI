using AutoMapper;
using FilmesApi.Data.DTO;
using FilmesApi.Interfaces;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FilmesApi.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<IEnumerable<SessaoDTO>> GetAllAsync()
        {
            var sessoes = await _sessaoService.GetAll();
            return sessoes;
        }


        [HttpGet("{id}")]
        public async Task<SessaoDTO> GetByIdAsync(int id)
        {
            var sessaoDto = await _sessaoService.GetByIdAsync(id);
            return sessaoDto;
        }

        [HttpPost]
        public void Add([FromBody] SessaoDTO sessaoDto)
        {
            var sessao = _mapper.Map<Sessao>(sessaoDto);
            _sessaoService.AddAsync(sessao);
        }


        [HttpPut("{id}")]
        public void Update(int id, [FromBody] SessaoDTO sessaoDto)
        {
            sessaoDto.Id = id;
            _sessaoService.Update(sessaoDto);
        }


        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _sessaoService.DeleteByIdAsync(id);
        }
    }
}
