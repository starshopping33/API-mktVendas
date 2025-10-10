using API_mktVendas.Application.Service;
using Microsoft.AspNetCore.Mvc;
using Paket;
using static API_mktVendas.Application.Dto.AuthDto;

namespace tech_store_api.API.Controllers
{
    public class AuthController
    {
        [ApiController]
        [Route("auth")]
    public class AuthController(UsuarioService usuario ) : ControllerBase
    {

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var token = await usuario.LoginAsync(dto.Email, dto.Password);
            return Ok(new AuthResponse(token));
        }
    }
}
