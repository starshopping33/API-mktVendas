using API_mktVendas.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using projeto_vwndas.Projeto_Vendas_API.Domain.Entities;

using tech_store_api.Infrastructure.Data;
using XAct.Users;

namespace tech_store_api.Infrastructure.Repositories
{
    public class UsuarioRepository(AppDbContext db) : IUsusarioRepository

    {
        public async Task<Usuario?> GetByEmailAsync(string email) =>
            await db.Usuario.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);

        public async Task AddAsync(Usuario usuario)
        {
            db.Usuario.Add(usuario);
            await db.SaveChangesAsync();
        }
    }
}