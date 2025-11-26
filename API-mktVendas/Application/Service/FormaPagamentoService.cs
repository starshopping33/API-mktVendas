using API_mktVendas.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using API_mktVendas.Infrastructure.Data;

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

    public async Task MarcarComoPagoAsync(int id)
    {
        var pagamento = await _db.FormaPagamentos.FirstOrDefaultAsync(p => p.Id == id);
        if (pagamento == null)
        {
            throw new Exception("Pagamento não encontrado.");
        }
        pagamento.Status = "Pago";
        _db.FormaPagamentos.Update(pagamento);
        await _db.SaveChangesAsync();
    }
}
