using API_mktVendas.API.Controller;
using API_mktVendas.Application.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using projeto_vwndas.Projeto_Vendas_API.Domain.Entities;

namespace projeto_vwndas.Projeto_Vendas_API.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _service;

        
        public UsuarioController(UsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var usuario = _service.ObterUsuario();
            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult CreateCadastro([FromBody] Usuario usuario)
        {
            if (usuario == null || string.IsNullOrEmpty(usuario.Email) || string.IsNullOrEmpty(usuario.Senha) || string.IsNullOrEmpty(usuario.Cpf))
                return BadRequest("Cadastro inválido.");

            if (!CpfValidate.Validar(usuario.Cpf))
                return BadRequest("CPF inválido.");

            var hasher = new PasswordHasher<Usuario>();
            usuario.SenhaHash = hasher.HashPassword(usuario, usuario.Senha);

            
            usuario.Senha = null;

            var createdCadastro = _service.CriarUsuario(usuario);

            return CreatedAtAction(nameof(Get), new { id = createdCadastro.Id }, createdCadastro);
        }

    }
}
