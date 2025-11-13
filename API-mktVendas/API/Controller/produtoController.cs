using API_mktVendas.Application.Service;
using Microsoft.AspNetCore.Mvc;
using projeto_vwndas.Projeto_Vendas_API.Domain.Entities;

namespace projeto_vwndas.Projeto_Vendas_API.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class produto : ControllerBase
    {
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





         
        [HttpPut("atualizar-estoque/{id}")]
        public async Task<IActionResult> AtualizarEstoque(int id, [FromBody] int novaQuantidade)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
                return NotFound("Produto não encontrado.");

            produto.Quantidade = novaQuantidade;
            await _context.SaveChangesAsync();

            return Ok(produto);
        }

        [HttpPut("diminuir-estoque/{id}")]
        public async Task<IActionResult> DiminuirEstoque(int id, [FromBody] int quantidadeVendida)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
                return NotFound("Produto não encontrado.");

            if (produto.Quantidade < quantidadeVendida)
                return BadRequest("Estoque insuficiente.");

            produto.Quantidade -= quantidadeVendida;
            await _context.SaveChangesAsync();

            return Ok(produto);
        }
    }
}
