using API_mktVendas.API.Controller;
using API_mktVendas.Application.Service;
using Microsoft.AspNetCore.Mvc;
using Paket;


using static API_mktVendas.Application.Dto.AuthDto;

namespace tech_store_api.API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController(UsuarioService auth) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Cpf))
                throw new Exception("O CPF é obrigatório.");

            if (!CpfValidate.Validar(dto.Cpf))
                return BadRequest("CPF inválido.");

            await auth.RegisterAsync(dto.Nome, dto.Cpf, dto.Email, dto.Password);
            return Created("", new { dto.Email });
        }



        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var token = await auth.LoginAsync(dto.Email, dto.Password);
            return Ok(new AuthResponse(token));
        }

        [HttpPatch("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateDto dto)
        {
            var usuario = await auth.UpdateUsuarioAsync(id, dto);
            if (usuario == null)
                return NotFound("Usuário não encontrado.");

            return Ok(new
            {
                message = "Usuário atualizado com sucesso!",
                usuario = new
                {
                    usuario.Id,
                    usuario.Nome,
                    usuario.Email,
                    usuario.Cpf,
                }
                });



        }
    }
}