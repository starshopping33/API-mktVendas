using API_mktVendas.Domain.Entities;
using tech_store_api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class PedidoService
{
    private readonly AppDbContext _db;
    private readonly FormaPagamentoService _pagamentoService;

    public PedidoService(AppDbContext db, FormaPagamentoService pagamentoService)
    {
        _db = db;
        _pagamentoService = pagamentoService;
    }

    public async Task<Pedido> CriarPedidoAsync(string tipoPagamento, decimal valor)
    {
        // 1. Criar pagamento
        var pagamento = await _pagamentoService.CriarPagamentoAsync(tipoPagamento, valor);

        // 2. Criar pedido vinculado ao pagamento
        var pedido = new Pedido
        {
            Status = "Em Andamento",
            DataCriacao = DateTime.UtcNow,
            FormaPagamentoId = pagamento.Id
        };

        _db.Pedidos.Add(pedido);
        await _db.SaveChangesAsync();

        return pedido;
    }

    public async Task FinalizarCompraAsync(int pagamentoId)
    {
        var pedido = await _db.Pedidos
            .FirstOrDefaultAsync(p => p.FormaPagamentoId == pagamentoId);

        if (pedido == null)
            throw new Exception("Pedido não encontrado.");

        if (pedido.Status != "Em Andamento")
            throw new Exception("O pedido não pode ser finalizado.");

        await _pagamentoService.MarcarComoPagoAsync(pagamentoId);

        pedido.Status = "Finalizado";
        pedido.DataFinalizacao = DateTime.UtcNow;

        await _db.SaveChangesAsync();
    }
}
