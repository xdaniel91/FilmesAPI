using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UsuariosApi.Interfaces;
using UsuariosApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UsuariosApi.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> LoginUsuarioAsync(LoginRequest request)
        {
            var result = await _loginService.LoginUsuarioAsync(request);
            if (result.IsSuccess) return Ok();
            return BadRequest(result);
        }
    }
}
