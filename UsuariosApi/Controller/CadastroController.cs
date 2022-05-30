using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UsuariosApi.Dto;
using UsuariosApi.Interfaces;
using UsuariosApi.Services;

namespace UsuariosApi.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public CadastroController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CriarUsuarioAsync(UsuarioDTO usuarioDto)
        {
            var result = await _service.CreateAsync(usuarioDto);
            if (result.IsFailed) return StatusCode(500);
            return Ok(result.Successes[^1].Message);
        }

        [HttpPost("/ativacao")]
        public async Task<IActionResult> AtivarUsuario(AtivaContaRequest request)
        {
            var result = _service.AtivarConta(request);
            if (result.IsCompletedSuccessfully) return Ok();
            return BadRequest();
        }
    }
}