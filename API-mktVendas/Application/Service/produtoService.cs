using projeto_vwndas.Projeto_Vendas_API.Domain.Entities;
using projeto_vwndas.Projeto_Vendas_API.Domain.Interfaces;

namespace API_mktVendas.Application.Service
{
    public class ProdutoService
  
    {
        private readonly IProdutoRepository _repo;

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

        public Produto Atualizarproduto(Produto produto)
        {
            _repo.Atualizar(produto);
            return produto;
        }

        internal object Deletarproduto(Produto produto)
        {
            throw new NotImplementedException();
        }
    }
}
