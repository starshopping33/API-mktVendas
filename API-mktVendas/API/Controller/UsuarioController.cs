using API_mktVendas.API.Controller;
using API_mktVendas.Application.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using projeto_vwndas.Projeto_Vendas_API.Domain.Entities;
using static API_mktVendas.Application.Dto.AuthDto;

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

            
            usuario.Senha = null;

            var createdCadastro = _service.RegisterAsync(usuario);

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

    }
}
