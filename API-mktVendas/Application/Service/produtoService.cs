
using projeto_vwndas.Projeto_Vendas_API.Domain.Entities;
using projeto_vwndas.Projeto_Vendas_API.Domain.Interfaces;

namespace API_mktVendas.Application.Service
{
    public class produtoService
  
    {
        private readonly IprodutoRepository _repo;

        public produtoService(IprodutoRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<produto> Obterproduto()
        {
            return _repo.ListarTodos();
        }

        public produto? ObterprodutoPorId(int id)
        {
            return _repo.ObterPorId(id);
        }

        public produto Criarproduto(produto produto)
        {
            _repo.Add(produto);
            return produto;
        }
    }
}
