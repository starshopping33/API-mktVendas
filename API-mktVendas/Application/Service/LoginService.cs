using API_mktVendas.Domain.Entities;
using API_mktVendas.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using projeto_vwndas.Projeto_Vendas_API.Domain.Entities;
using projeto_vwndas.Projeto_Vendas_API.Domain.Interfaces;

namespace API_mktVendas.Application.Service
{
    public class LoginService
    {
        private readonly ILoginRepository _repo;

        public LoginService(ILoginRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Login> ObterLogin()
        {
            return _repo.ListarTodos();
        }

        public Login? ObterUsuarioPorId(int id)
        {
            return _repo.ObterPorId(id);
        }

        public Login CriarUsuario(Login login)
        {
            _repo.Add(login);
            return login;
        }

        public Login? ObterUsuarioPorEmail(string email)
        {
            
            return _repo.ObterPorEmail(email);
        }
    }
}
