using Microsoft.IdentityModel.Tokens;
using projeto_vwndas.Projeto_Vendas_API.Domain.Entities;
using projeto_vwndas.Projeto_Vendas_API.Domain.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_mktVendas.Application.Service
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _repo;
        private readonly IConfiguration _cfg;

        public UsuarioService(IUsuarioRepository repo, IConfiguration cfg)
        {
            _repo = repo;
            _cfg = cfg;
        }

        public IEnumerable<Usuario> ObterUsuario()
        {
            return _repo.ListarTodos();
        }

        public Usuario? ObterUsuarioPorId(int id)
        {
            return _repo.ObterPorId(id);
        }

        public Usuario RegisterAsync(Usuario usuario)
        {
            _repo.Add(usuario);
            return usuario;
        }
        public Usuario ObterUsuarioPorEmail(string email)

        {
            return _repo.ObterPorEmail(email);
        }

        public async Task RegisterAsync(string email, string password)
        {
            email = email.Trim().ToLowerInvariant();

            var exists = await _repo.GetByEmailAsync(email);
            if (exists is not null)
                throw new InvalidOperationException("Email já registrado.");

            var hash = BCrypt.Net.BCrypt.HashPassword(password);
            await _repo.AddAsync(new Usuario { Email = email, SenhaHash = hash });
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            email = email.Trim().ToLowerInvariant();

            var user = await _repo.GetByEmailAsync(email);
            if (user is null || !BCrypt.Net.BCrypt.Verify(password, user.SenhaHash))
                throw new UnauthorizedAccessException("Credenciais inválidas.");

            return GenerateToken(user.Email, _cfg);
        }

        private string GenerateToken(string email, IConfiguration cfg)
        {
            var jwt = cfg.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Key"]!));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: jwt["Issuer"],
                audience: jwt["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(int.TryParse(jwt["ExpirationMinutes"], out var m) ? m : 60),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public Usuario? UpdateUsuario(Usuario usuario)
        {
          
            var existingUsuario = _repo.ObterPorId(usuario.Id);
            if (existingUsuario == null)
                return null;

        
            if (!string.IsNullOrEmpty(usuario.Nome))
                existingUsuario.Nome = usuario.Nome;

            if (!string.IsNullOrEmpty(usuario.Email))
                existingUsuario.Email = usuario.Email;

            if (!string.IsNullOrEmpty(usuario.Cpf))
                existingUsuario.Cpf = usuario.Cpf;

           
            if (!string.IsNullOrEmpty(usuario.Senha))
                existingUsuario.SenhaHash = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);

            
            _repo.Update(existingUsuario);

            return existingUsuario;
        
    }
    }

}