using API_mktVendas.Application.Service;
using API_mktVendas.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using projeto_vwndas.Projeto_Vendas_API.Domain.Entities;
using XAct;

namespace projeto_vwndas.Projeto_Vendas_API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class produto : ControllerBase


    {
        private readonly AppDbContext _context;

        private readonly ProdutoService _service;
        private readonly object criarprodutoId;
        private object criarproduto;

        public produto(ProdutoService service)
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
        public IActionResult CreateCadastro([FromBody] Produto produto)
        {
            if (produto == null)
                return BadRequest("Cadastro inválido.");

            var createdCadastro = _service.Criarproduto(produto);

            return CreatedAtAction(nameof(Get), new { id = criarproduto },criarproduto);
        }

        [HttpPut]
          public IActionResult AtualizarProduto([FromBody] Produto produto)
         {
            if (produto == null)
             return BadRequest();

         var AtualizarProduto = _service.Atualizarproduto(produto);

         return CreatedAtAction(nameof(Get), new {  AtualizarProduto }, AtualizarProduto);
         }


        [HttpDelete]
        public IActionResult DeletarProduto([FromBody] Produto produto)
        {
            if (produto == null)
                return BadRequest("item excluido.");

            var DeletarProduto = _service.Deletarproduto(produto);

            return CreatedAtAction(nameof(Get), new { id = DeletarProduto }, DeletarProduto);
        }


         
    }
}
