using API_mktVendas.Application.Service;
using API_mktVendas.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using projeto_vwndas.Projeto_Vendas_API.Domain.Entities;

namespace API_mktVendas.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public LoginController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] Login login)
        {
            if (login == null || string.IsNullOrEmpty(login.Email) || string.IsNullOrEmpty(login.Senha))
                return BadRequest("Login inválido.");

            
            var usuario = _usuarioService.ObterUsuarioPorEmail(login.Email);
            if (usuario == null)
                return Unauthorized("Usuário não encontrado.");

           
            var hasher = new PasswordHasher<Usuario>();
            var result = hasher.VerifyHashedPassword(usuario, usuario.SenhaHash, login.Senha);

            if (result == PasswordVerificationResult.Success)
                return Ok("Login bem-sucedido!");
            else
                return Unauthorized("Senha incorreta.");
        }
    }
}
