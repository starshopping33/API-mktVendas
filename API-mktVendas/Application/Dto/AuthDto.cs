namespace API_mktVendas.Application.Dto
{
    public class AuthDto
    {
        public class RegisterDto
        {
            public string Nome { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string Cpf { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
        }

        public class LoginDto
        {
            public string Email { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
        }

        public record AuthResponse(string Token);
    }
}