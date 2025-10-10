using projeto_vwndas.Projeto_Vendas_API.Domain.Entities;
using projeto_vwndas.Projeto_Vendas_API.Domain.Interfaces;

using projeto_vwndas.Projeto_Vendas_API.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using API_mktVendas.Infrastructure.Data;

namespace projeto_vwndas.Projeto_Vendas_API.Infrastructure.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

      public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Produto> ListarTodos()
        {
            return _context.Produto.ToList();
        }

        public Produto ObterPorId(int id)
        {
            return _context.Produto.Find(id);
        }

        public void Adicionar(Produto produto)
        {
            _context.Produto.Add(produto);
        }

        public void Atualizar(Produto produto)
        {
            _context.Produto.Update(produto);
        }

        public void Remover(int id)
        {
            var produto = _context.Produto.Find(id);
            if (produto != null)
                _context.Produto.Remove(produto);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }

        public void Add(Produto produto)
        {
            _context.Produto.Add(produto);
            _context.SaveChanges();
        }
    }
}