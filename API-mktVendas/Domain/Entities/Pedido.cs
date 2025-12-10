using System;

namespace API_mktVendas.Domain.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime DataCriacao { get; set; }

        public DateTime DataFinalizacao { get; set; }


        public int FormaPagamentoId { get; set; }

       
        public FormaPagamento FormaPagamento { get; set; }
    }
}
