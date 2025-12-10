using API_mktVendas.Application.Service;
using API_mktVendas.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("MinhasCompras")]
public class MinhasComprasController : ControllerBase
{
    private readonly HistoricoDeComprasService _service;

    public MinhasComprasController(HistoricoDeComprasService service)
    {
        _service = service;
    }

    [HttpGet("{usuarioId:int}")]
    public async Task<IActionResult> Listar(int usuarioId)
    {
        var compras = await _service.MinhasCompras(usuarioId);
        return Ok(compras);
    }
}