using projeto_vwndas.Projeto_Vendas_API.Domain.Entities;
using System.Threading.Tasks;

using XAct.Users;

namespace tech_store_api.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        IEnumerable<Usuario> ListarTodos();
        void Add(Usuario usuario);
        Usuario ObterPorId(int id);
        Usuario ObterPorEmail(string email);

        Task AddAsync(Usuario usuario);
        
        Task<Usuario?> GetByEmailAsync(string email);

        void Update(Usuario usuario);
        void SaveChanges();

    }
}
