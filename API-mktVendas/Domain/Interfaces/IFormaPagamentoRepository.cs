using API_mktVendas.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IFormaPagamentoRepository
{
    Task<FormaPagamento> AddAsync(FormaPagamento pagamento);
    Task<FormaPagamento?> GetByIdAsync(int id);
    Task<List<FormaPagamento>> GetAllAsync();
    Task UpdateAsync(FormaPagamento pagamento);
    Task DeleteAsync(FormaPagamento pagamento);
}