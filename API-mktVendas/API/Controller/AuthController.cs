using API_mktVendas.API.Controller;
using API_mktVendas.Application.Dto;
using API_mktVendas.Application.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Paket;
using System.Security.Claims;
using static API_mktVendas.Application.Dto.AuthDto;

namespace tech_store_api.API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController(UsuarioService auth) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterDto dto)
        {

            var maior = auth.IsMaiorIdade(dto.DataNascimento);

            if (!maior)
                return BadRequest(new { message = "O usuário deve ter pelo menos 18 anos." });

            if (string.IsNullOrWhiteSpace(dto.Cpf))
                throw new Exception("O CPF é obrigatório.");

            if (!CpfValidate.Validar(dto.Cpf))
                return BadRequest("CPF inválido.");

            await auth.RegisterAsync(dto.Nome, dto.Cpf, dto.Email, dto.Telefone, dto.DataNascimento , dto.Password);
            return Created("", new { dto.Email, dto.Nome});
        }


        [HttpGet("GET")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await auth.GetAllUsersAsync();
            return Ok(users);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var token = await auth.LoginAsync(dto.Email, dto.Password);
            return Ok(new AuthResponse(token));
        }

        


        [HttpPatch("Update/{id:int}")]
        public async Task<IActionResult> UpdateUsuario(int id, [FromBody] AuthDto.UpdateDto dto)
        {
            try
            {
                if (dto == null)        
                    return BadRequest("Dados inválidos.");

                var usuario = await auth.UpdateUsuarioAsync(id, dto);

                if (usuario == null)
                    return NotFound("Usuário não encontrado.");

                return Ok(new
                {
                    message = "Usuário atualizado com sucesso!",
                    usuario
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Erro interno no servidor", detail = ex.Message });
            }
        }
        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var deleted = await auth.DeleteUsuarioAsync(id);

            if (!deleted)
                return NotFound(new { message = $"Usuário com ID {id} não encontrado." });

            return Ok(new { message = $"Usuário {id} deletado com sucesso!" });
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var usuario = await auth.GetByIdAsync(id);

                if (usuario == null)
                    return NotFound(new { message = "Usuário não encontrado." });

                return Ok(usuario);
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, new { error = "Erro interno no servidor.", details = ex.Message });
            }
        }



        //[HttpGet("login-google")]
        //public IActionResult LoginGoogle()
        //{
        //    Provider 
        //}

       
        


    }
}