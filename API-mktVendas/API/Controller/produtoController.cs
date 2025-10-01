using API_mktVendas.Application.Service;
using Microsoft.AspNetCore.Mvc;
using projeto_vwndas.Projeto_Vendas_API.Domain.Entities;

namespace projeto_vwndas.Projeto_Vendas_API.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class produto : ControllerBase
    {
        private readonly produtoService _service;


        public produto(produtoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var produto = _service.Obterproduto();
            return Ok(produto);
        }

        [HttpPost]
        public IActionResult CreateCadastro([FromBody] produto produto)
        {
            if (produto == null)
                return BadRequest("Cadastro inválido.");

            var createdCadastro = _service.Criarproduto(produto);

            return CreatedAtAction(nameof(Get), new { id = createdCadastro.Id }, createdCadastro);
        }


    }
}
