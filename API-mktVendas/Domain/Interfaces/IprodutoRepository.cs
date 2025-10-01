using projeto_vwndas.Projeto_Vendas_API.Domain.Entities;

namespace projeto_vwndas.Projeto_Vendas_API.Domain.Interfaces
{
    public interface IprodutoRepository
    {
        IEnumerable<produto> ListarTodos();
        void Add(produto produto);
      

    }
}
