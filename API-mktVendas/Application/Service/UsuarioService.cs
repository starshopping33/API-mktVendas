using projeto_vwndas.Projeto_Vendas_API.Domain.Entities;
using projeto_vwndas.Projeto_Vendas_API.Domain.Interfaces;

namespace API_mktVendas.Application.Service
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _repo;

        public UsuarioService(IUsuarioRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Usuario> ObterUsuario()
        {
            return _repo.ListarTodos();
        }

        public Usuario? ObterUsuarioPorId(int id)
        {
            return _repo.ObterPorId(id);
        }

        public Usuario CriarUsuario(Usuario usuario)
        {

            _repo.Add(usuario);
            return usuario;
        }

        public Usuario? ObterPorEmail(string email)
        {
            return _repo.ObterPorEmail(email);
        }


    }
}
