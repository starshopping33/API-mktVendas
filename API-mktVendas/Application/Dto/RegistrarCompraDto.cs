namespace API_mktVendas.Application.Dto
{
    public class RegistrarCompraDto
    {
        public int UsuarioId { get; set; }
        public int ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
