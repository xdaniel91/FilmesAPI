using AutoMapper;
using FilmesApi.Data.DTO;
using FilmesApi.Interfaces;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FilmesApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GerenteController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGerenteService _gerenteService;

        public GerenteController(IGerenteService gerenteService, IMapper mapper)
        {
            _mapper = mapper;
            _gerenteService = gerenteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var gerentes = await _gerenteService.GetAll();
            var gerentesDto = _mapper.Map<GerenteDTO>(gerentes);
            return Ok(gerentesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var gerente = await _gerenteService.GetByIdAsync(id);
            var gerenteDto = _mapper.Map<GerenteDTO>(gerente);
            return Ok(gerenteDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] GerenteDTO gerenteDto)
        {
            await _gerenteService.AddAsync(gerenteDto);
            return CreatedAtAction(nameof(gerenteDto), gerenteDto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] GerenteDTO gerenteDto)
        {
            gerenteDto.Id = id;
            _gerenteService.Update(gerenteDto);
            return Ok(gerenteDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _gerenteService.DeleteByIdAsync(id);
            return NoContent();
        }
    }
}
