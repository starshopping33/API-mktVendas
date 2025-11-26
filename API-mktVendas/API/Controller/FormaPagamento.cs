using API_mktVendas.Application.Service;
using Microsoft.AspNetCore.Mvc;
using static API_mktVendas.Application.Dto.FormaPagamentoDto;

namespace API_mktVendas.API.Controller
{
    [ApiController]
    [Route("FormaPagamento")]
    public class FormaPagamentoController : ControllerBase
    {
        private readonly FormaPagamentoService _service;

        public FormaPagamentoController(FormaPagamentoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CriarPagamento([FromBody] CriarPagamentoDto dto)
        {
            if (dto.Valor <= 0)
                return BadRequest("O valor deve ser maior que zero.");

            if (string.IsNullOrWhiteSpace(dto.Tipo))
                return BadRequest("O tipo de pagamento é obrigatório.");

            var pagamento = await _service.CriarPagamentoAsync(dto.Tipo, dto.Valor);

            return Ok(new
            {
                message = "Pagamento criado com sucesso.",
                pagamento
            });
        }

        [HttpPatch("Pagar/{id:int}")]
        public async Task<IActionResult> MarcarComoPago(int id)
        {
            try
            {
                await _service.MarcarComoPagoAsync(id);
                return Ok(new { message = "Pagamento pago com sucesso." });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = "falha ao realizar o pagamento" });
            }
        }
    }
}