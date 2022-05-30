using Microsoft.AspNetCore.Mvc;


namespace UsuariosApi.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class LogoutController : ControllerBase
    {
        private readonly ILogoutService _logoutService;

        public LogoutController(ILogoutService logoutService)
        {
            _logoutService = logoutService;
        }

        [HttpPost]
        public IActionResult Deslogar()
        {
            var result = _logoutService.Deslogar();
            if (result.IsSuccess) return Ok();
            return BadRequest(result);
        }
    }
}
