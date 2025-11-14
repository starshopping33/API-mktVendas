using API_mktVendas.Domain.Entities;
using tech_store_api.Infrastructure.Data;

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
            //Tipo = tipo,
            //Valor = valor,
            //Status = "Pendente"
        };

        _db.FormaPagamentos.Add(pagamento);
        await _db.SaveChangesAsync();

        return pagamento;
    }
}
