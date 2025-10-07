namespace API_mktVendas.Application.Dto
{
    public class AuthDto
    {
        public record RegisterDto(string Email, string Password);
        public record LoginDto(string Email, string Password);
        public record AuthResponse(string Token);
    }
}
