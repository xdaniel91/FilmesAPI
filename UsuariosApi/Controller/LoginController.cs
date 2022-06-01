using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UsuariosApi.Interfaces;
using UsuariosApi.Requests;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UsuariosApi.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IUsuarioService _userService;

        public LoginController(ILoginService loginService, IUsuarioService userService)
        {
            _loginService = loginService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> LoginUsuarioAsync(LoginRequest request)
        {
            var result = await _loginService.LoginUsuarioAsync(request);
            if (result.IsSuccess) return Ok();
            return BadRequest(result);
        }

        [HttpPost("/solicita-reset")]
        public async Task<IActionResult> SolicitaResetSenha(ResetSenhaRequest request)
        {
            var result = await _loginService.SolicitaResetSenha(request);
            if (result.IsSuccess) return Ok(result.Successes[^1]);
            return BadRequest();
        }

        [HttpPost("/efetua-reset")]
        public async Task<IActionResult> ResetaSenha(EfetuaResetRequest request)
        {
            var result = await _loginService.EfetuaReset(request);
            if (result.IsSuccess) return Ok(result.Successes[^1]);
            return BadRequest();
        }
    }
}