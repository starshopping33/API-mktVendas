namespace API_mktVendas.Domain.Entities
{
    public class HistoricoCompra
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataCompra { get; set; }
    }
}