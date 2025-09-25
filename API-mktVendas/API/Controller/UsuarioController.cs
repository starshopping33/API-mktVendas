using API_mktVendas.Application.Service;
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
            if (usuario == null)
                return BadRequest("Cadastro inválido.");

            var createdCadastro = _service.CriarUsuario(usuario);

            return CreatedAtAction(nameof(Get), new { id = createdCadastro.Id }, createdCadastro);
        }

       
    }
}
