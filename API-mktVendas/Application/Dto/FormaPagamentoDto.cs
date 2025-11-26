namespace API_mktVendas.Application.Dto
{
    public class FormaPagamentoDto
    {

        public class CriarPagamentoDto
        {
            public string Tipo { get; set; } = string.Empty;
            public decimal Valor { get; set; }

            public int UsuarioId { get; set; } 

            public int ProdutoId { get; set; } 
        }
    }
}
