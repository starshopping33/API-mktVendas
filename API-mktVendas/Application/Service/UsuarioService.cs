using API_mktVendas.Domain.Interfaces;
using Microsoft.IdentityModel.Tokens;
using projeto_vwndas.Projeto_Vendas_API.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


using XAct.Users;
using static API_mktVendas.Application.Dto.AuthDto;

namespace API_mktVendas.Application.Service
{
    public class UsuarioService(IUsusarioRepository repo, IConfiguration cfg)
    {
        public async Task RegisterAsync(string nome, string cpf,string email, string password)
        {
            email = email.Trim().ToLowerInvariant();
            var exists = await repo.GetByEmailAsync(email);
            if (exists is not null) throw new InvalidOperationException("Email já registrado.");

            var hash = BCrypt.Net.BCrypt.HashPassword(password);
            await repo.AddAsync(new Usuario { Nome = nome, Cpf = cpf, Email = email, SenhaHash = hash });
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            email = email.Trim().ToLowerInvariant();
            var user = await repo.GetByEmailAsync(email);
            if (user is null || !BCrypt.Net.BCrypt.Verify(password, user.SenhaHash))
                throw new UnauthorizedAccessException("Credenciais inválidas.");

            return GenerateToken(user.Email);
        }

        private string GenerateToken(string email)
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
                issuer: jwt["Issuer"], audience: jwt["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(int.TryParse(jwt["ExpirationMinutes"], out var m) ? m : 60),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<Usuario?> UpdateUsuarioAsync(int id, UpdateDto dto)
        {
            var usuario = await repo.GetByIdAsync(id);
            if (usuario == null)
                return null;

            if (!string.IsNullOrWhiteSpace(dto.Nome))
                usuario.Nome = dto.Nome;

            if (!string.IsNullOrWhiteSpace(dto.Email))
                usuario.Email = dto.Email;

            if (!string.IsNullOrWhiteSpace(dto.Cpf))
                usuario.Cpf = dto.Cpf;

            if (!string.IsNullOrWhiteSpace(dto.Password))
                usuario.SenhaHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            await repo.UpdateAsync(usuario);
            await repo.SaveChangesAsync();

            return usuario;
        }
    }
}