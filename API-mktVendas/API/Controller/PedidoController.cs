using API_mktVendas.Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace API_mktVendas.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService _service;

        public PedidoController(PedidoService service)
        {
            _service = service;
        }

        [HttpPost("finalizar/{pagamentoId}")]
        public async Task<IActionResult> Finalizar(int pagamentoId)
        {
            await _service.FinalizarCompraAsync(pagamentoId);
            return Ok(new { mensagem = "Pedido finalizado com sucesso!" });
        }
    }
}
