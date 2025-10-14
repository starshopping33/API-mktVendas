using Microsoft.EntityFrameworkCore;
using projeto_vwndas.Projeto_Vendas_API.Domain.Entities;
using projeto_vwndas.Projeto_Vendas_API.Domain.Interfaces;

using tech_store_api.Infrastructure.Data;
using XAct.Library.Settings;
using XAct.Users;
using Db = Sitecore.FakeDb.Db;

namespace projeto_vwndas.Projeto_Vendas_API.Infrastructure.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Usuario> ListarTodos()
        {
            return _context.Usuario.ToList();
        }

        public Usuario ObterPorId(int id)
        {
            return _context.Usuario.Find(id);
        }

        public void Adicionar(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
        }

        public void Atualizar(Usuario usuario)
        {
            _context.Usuario.Update(usuario);
        }

        public void Remover(int id)
        {
            var usuario = _context.Usuario.Find(id);
            if (usuario != null)
                _context.Usuario.Remove(usuario);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }

        public void Add(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
        }

        public Usuario ObterPorEmail(string email)
        {
            return _context.Usuario.FirstOrDefault(u => u.Email == email);
        }

        public async Task AddAsync(Usuario usuario)
        {
            await _context.Usuario.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            return await _context.Usuario
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public void Update(Usuario usuario)
        {
            _context.Usuario.Update(usuario);
            _context.SaveChanges(); 
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}