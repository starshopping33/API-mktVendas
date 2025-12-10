
using API_mktVendas.Application.Dto;
using API_mktVendas.Domain.Entities;

using API_mktVendas.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace API_mktVendas.Application.Service;
public class HistoricoDeComprasService
{
    private readonly AppDbContext _context;

    public HistoricoDeComprasService(AppDbContext context)
    {
        _context = context;
    }

    
    
    public async Task RegistrarCompra(RegistrarCompraDto dto)
    {
        var compra = new HistoricoCompra
        {
            UsuarioId = dto.UsuarioId,
            ProdutoId = dto.ProdutoId,
            NomeProduto = dto.NomeProduto,
            ValorTotal = dto.ValorTotal,
            DataCompra = DateTime.Now
        };

        _context.HistoricoCompras.Add(compra);
        await _context.SaveChangesAsync();
    }

    public async Task<List<FormaPagamento>> MinhasCompras(int usuarioId)
    {
        return await _context.FormaPagamentos
            .Where(fp => fp.UsuarioId == usuarioId)
            .OrderByDescending(fp => fp.Id)
            .ToListAsync();
    }
}