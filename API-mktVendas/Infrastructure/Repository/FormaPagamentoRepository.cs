using API_mktVendas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using tech_store_api.Infrastructure.Data;

namespace API_mktVendas.Infrastructure.Repository
{
    public class FormaPagamentoRepository
    {
        private readonly AppDbContext _db;

        public FormaPagamentoRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<FormaPagamento> AddAsync(FormaPagamento pagamento)
        {
            _db.FormaPagamentos.Add(pagamento);
            await _db.SaveChangesAsync();
            return pagamento;
        }

        public async Task<FormaPagamento?> GetByIdAsync(int id)
        {
            return await _db.FormaPagamentos.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<FormaPagamento>> GetAllAsync()
        {
            return await _db.FormaPagamentos.ToListAsync();
        }

        public async Task UpdateAsync(FormaPagamento pagamento)
        {
            _db.FormaPagamentos.Update(pagamento);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(FormaPagamento pagamento)
        {
            _db.FormaPagamentos.Remove(pagamento);
            await _db.SaveChangesAsync();
        }
    }
}
