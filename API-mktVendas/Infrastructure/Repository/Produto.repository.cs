using projeto_vwndas.Projeto_Vendas_API.Domain.Entities;
using projeto_vwndas.Projeto_Vendas_API.Domain.Interfaces;

using projeto_vwndas.Projeto_Vendas_API.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace projeto_vwndas.Projeto_Vendas_API.Infrastructure.Repository
{
    public class produtoRepository : IprodutoRepository
    {
        private readonly AppDbContext _context;

      public produtoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<produto> ListarTodos()
        {
            return _context.produto.ToList();
        }

        public produto ObterPorId(int id)
        {
            return _context.produto.Find(id);
        }

        public void Adicionar(produto produto)
        {
            _context.Produto.Add(produto);
        }

        public void Atualizar(produto produto)
        {
            _context.produto.Update(produto);
        }

        public void Remover(int id)
        {
            var produto = _context.produto.Find(id);
            if (produto != null)
                _context.produto.Remove(produto);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }

        public void Add(produto produto)
        {
            _context.produto.Add(produto);
            _context.SaveChanges();
        }
    }
}