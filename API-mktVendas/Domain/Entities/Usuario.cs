namespace projeto_vwndas.Projeto_Vendas_API.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }

        public string cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
