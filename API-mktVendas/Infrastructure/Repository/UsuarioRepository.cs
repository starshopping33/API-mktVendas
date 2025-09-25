using projeto_vwndas.Projeto_Vendas_API.Domain.Entities;
using projeto_vwndas.Projeto_Vendas_API.Domain.Interfaces;
using tech_store_api.Infrastructure.Data;

using projeto_vwndas.Projeto_Vendas_API.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

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
    }
}