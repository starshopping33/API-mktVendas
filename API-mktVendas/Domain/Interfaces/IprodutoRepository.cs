using projeto_vwndas.Projeto_Vendas_API.Domain.Entities;

namespace projeto_vwndas.Projeto_Vendas_API.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> ListarTodos();
        void Add(Produto produto);
    }
}
