using AutoMapper;
using FilmesApi.Data.DTO;
using FilmesApi.Interfaces;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IMapper mapper, IEnderecoService enderecoService)
        {
            _mapper = mapper;
            _enderecoService = enderecoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var enderecos = await _enderecoService.GetAll();
            return Ok(enderecos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var endereco = await _enderecoService.GetByIdAsync(id);
            if (endereco == null) return NotFound();
            var enderecoDto = _mapper.Map<EnderecoDTO>(endereco);
            return Ok(enderecoDto);
        }

        [HttpPost]
        public IActionResult Add([FromBody] EnderecoDTO enderecoDto)
        {
            var endereco = _mapper.Map<Endereco>(enderecoDto);
            _enderecoService.Add(endereco);
            return Ok(endereco);
        }

        [HttpPatch("{id}")]
        public IActionResult Update(int id, [FromBody] EnderecoDTO enderecoDto)
        {
            enderecoDto.Id = id;
            _enderecoService.Update(enderecoDto);
            return Ok(enderecoDto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _enderecoService.DeleteById(id);
            return Ok();
        }
    }
}