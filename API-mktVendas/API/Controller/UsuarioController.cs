using API_mktVendas.API.Controller;

using Microsoft.AspNetCore.Mvc;
using projeto_vwndas.Projeto_Vendas_API.Domain.Entities;
using static API_mktVendas.Application.Dto.AuthDto;

namespace projeto_vwndas.Projeto_Vendas_API.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly _service;

        
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
        public IActionResult RegisterAsync([FromBody] Usuario usuario)
        {
            if (usuario == null || string.IsNullOrEmpty(usuario.Email) || string.IsNullOrEmpty(usuario.Senha) || string.IsNullOrEmpty(usuario.Cpf))
                return BadRequest("Cadastro inválido.");

            if (!CpfValidate.Validar(usuario.Cpf))
                return BadRequest("CPF inválido.");

            
            usuario.Senha = null;

            var createdCadastro = _service.RegisterAsync(usuario.Email, usuario.SenhaHash);

            return CreatedAtAction(nameof(Get), new { id = createdCadastro.Id }, createdCadastro);
        }

      

        [HttpPatch("{id}")]
        public IActionResult UpdateUsuario(int id, [FromBody] Usuario usuario)
        {
            if (usuario == null)
                return BadRequest("Atualização inválida.");

            usuario.Id = id; 

            var updatedUsuario = _service.UpdateUsuario(usuario);

            if (updatedUsuario == null)
                return NotFound("Usuário não encontrado.");

            return Ok(updatedUsuario);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUsuario(int id)
        {
            var existingUsuario = _service.ObterUsuarioPorId(id);
            if (existingUsuario == null)
                return NotFound("Usuário não encontrado.");
            _service.DeleteUsuario(id);
            return NoContent();
        }

    }
}
