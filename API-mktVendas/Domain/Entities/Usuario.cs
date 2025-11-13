using System.ComponentModel.DataAnnotations.Schema;

namespace projeto_vwndas.Projeto_Vendas_API.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Cpf { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string Telefone { get; set; } = string.Empty;

        public bool IsAdmin { get; set; } = false;

        [NotMapped]
        public string? Senha { get; set; }

       
        public string SenhaHash { get; set; } = string.Empty;
        public string ImagemBase64 { get; internal set; }
    }
}
