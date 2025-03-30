using Microsoft.AspNetCore.Mvc;
using ProveedoresAPI.Application.Services;
using ProveedoresAPI.Domain;

namespace ProveedoresAPI.Presentation.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;

        public AuthController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Usuario usuario)
        {
            if (usuario.Username == "admin" && usuario.Password == "admin123")
            {
                var token = _jwtService.GenerateToken(usuario);
                return Ok(new { Token = token });
            }
            return Unauthorized();
        }
    }
}
