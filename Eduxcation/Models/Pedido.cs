using System;
using System.Collections.Generic;

#nullable disable

namespace Eduxcation.Models
{
    public partial class Pedido
    {
        public Pedido()
        {
            PedidoItems = new HashSet<PedidoItem>();
        }

        public int Id { get; set; }
        public int QtdProdutos { get; set; }
        public decimal TotalProdutos { get; set; }
        public decimal Frete { get; set; }
        public decimal TotalPedido { get; set; }
        public int ClienteId { get; set; }
        public DateTime DataPedido { get; set; }
        public string CondicaoPagto { get; set; }
        public int StatusPedido { get; set; }
        public string Observacao { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual StatusPedido StatusPedidoNavigation { get; set; }
        public virtual ICollection<PedidoItem> PedidoItems { get; set; }
    }
}
