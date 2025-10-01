namespace projeto_vwndas.Projeto_Vendas_API.Domain.Entities
{
    public class produto
    {
        public int Id { get; set; }

        public string nome { get; set; }
        public string preço{ get; set; }
        public string descriçao { get; set; }
        public string imagem { get; set; }
    }
}
