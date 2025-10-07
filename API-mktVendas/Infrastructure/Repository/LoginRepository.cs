using API_mktVendas.Domain.Entities;
using API_mktVendas.Domain.Interfaces;

using tech_store_api.Infrastructure.Data;

namespace API_mktVendas.Infrastructure.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly AppDbContext _context;

        public LoginRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Login> ListarTodos()
        {
            return _context.Login.ToList();
        }

        public Login ObterPorId(int id)
        {
            return _context.Login.Find(id);
        }

        public void Adicionar(Login login)
        {
            _context.Login.Add(login);
        }

        public void Atualizar(Login login)
        {
            _context.Login.Update(login);
        }

        public void Remover(int id)
        {
            var login = _context.Login.Find(id);
            if (login != null)
                _context.Login.Remove(login);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }

        public void Add(Login login
            )
        {
            _context.Login.Add(login);
            _context.SaveChanges();
        }

        public Login ObterPorEmail(string email)
        {
            return _context.Login.FirstOrDefault(l => l.Email == email);
        }

    }
}
