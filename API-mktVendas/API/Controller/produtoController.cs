using API_mktVendas.Application.Service;
using Microsoft.AspNetCore.Mvc;
using projeto_vwndas.Projeto_Vendas_API.Domain.Entities;

namespace projeto_vwndas.Projeto_Vendas_API.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _service;

        public ProdutoController(ProdutoService service)
        {
            _service = service;
        }

        // GET ALL
        [HttpGet]
        public IActionResult Get([FromQuery] string categoria)
        {
            var produtos = _service.Obterproduto();

            if (!string.IsNullOrEmpty(categoria) && categoria != "Todos")
                produtos = produtos.Where(p => p.categoria == categoria).ToList();

            return Ok(produtos);
        }

        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var produto = _service.ObterPorId(id);
            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        
        [HttpPost]
        public IActionResult Create([FromBody] Produto produto)
        {
            if (produto == null)
                return BadRequest("Produto inválido.");

            var created = _service.Criarproduto(produto);

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Produto produto)
        {
            if (produto == null || id != produto.Id)
                return BadRequest("Dados inconsistentes.");

            var atualizado = _service.Atualizarproduto(produto);

            return Ok(atualizado);
        }

     
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var apagado = _service.Deletarproduto(id);

            if (!apagado)
                return NotFound();

            return NoContent();
        }
    }
}
