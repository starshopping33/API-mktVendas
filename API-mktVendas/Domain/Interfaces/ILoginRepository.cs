using API_mktVendas.Domain.Entities;
using projeto_vwndas.Projeto_Vendas_API.Domain.Entities;

namespace API_mktVendas.Domain.Interfaces
{
    public interface ILoginRepository
    {
            IEnumerable<Login> ListarTodos();
            void Add(Login login);
            Login ObterPorId(int id);
            Login ObterPorEmail(string email);

    }
    }

