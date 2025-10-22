using projeto_vwndas.Projeto_Vendas_API.Domain.Entities;
using projeto_vwndas.Projeto_Vendas_API.Domain.Interfaces;

namespace API_mktVendas.Application.Service
{
    public class ProdutoService
  
    {
        private readonly IProdutoRepository _repo;
        private readonly object _context;

        public ProdutoService(IProdutoRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Produto> Obterproduto()
        {
            return _repo.ListarTodos();
        }

        //public Produto? ObterprodutoPorId(int id)
        //{
        //    return _repo.ObterPorId(id);
        //}

        public Produto Criarproduto(Produto produto)
        {
            _repo.Add(produto);
            return produto;
        }

        internal object Deletarproduto(Produto produto)
        {
            _repo.Deletar(produto);
            return produto;
        }

        internal object Atualizarproduto(Produto produto)
        {
            _repo.atualizar(produto);
            return produto;
            ;
           
        }
    }
}
