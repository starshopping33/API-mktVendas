using API_mktVendas.Domain.Entities;
using tech_store_api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class FormaPagamentoService
{
    private readonly AppDbContext _db;

    public FormaPagamentoService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<FormaPagamento> CriarPagamentoAsync(string tipo, decimal valor)
    {
        var pagamento = new FormaPagamento
        {
            Tipo = tipo,
            Valor = valor,
            Status = "Pendente"
        };

        _db.FormaPagamentos.Add(pagamento);
        await _db.SaveChangesAsync();

        return pagamento;
    }

    public async Task MarcarComoPagoAsync(int pagamentoId)
    {
        var pagamento = await _db.FormaPagamentos.FindAsync(pagamentoId);

        if (pagamento == null)
            throw new Exception("Pagamento não encontrado.");

        pagamento.Status = "Pago";
        await _db.SaveChangesAsync();
    }
}
