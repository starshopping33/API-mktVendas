﻿namespace projeto_vwndas.Projeto_Vendas_API.Domain.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Preco{ get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
    }
}
