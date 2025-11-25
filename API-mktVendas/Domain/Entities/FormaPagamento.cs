namespace API_mktVendas.Domain.Entities
{
    public class FormaPagamento
    {
        public int Id { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public string Status { get; set; } = "Pendente";
    }
}
