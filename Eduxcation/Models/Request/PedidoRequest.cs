using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduxcation.Models.Request
{
	public class PedidoRequest
	{

        public int QtdProdutos { get; set; }
        public decimal TotalProdutos { get; set; }
        public decimal Frete { get; set; }
        public decimal TotalPedido { get; set; }
        public int ClienteId { get; set; }
        public DateTime DataPedido { get; set; }
        public string CondicaoPagto { get; set; }
        public int StatusPedido { get; set; }
        public string Observacao { get; set; }
        public List<PedidoItemRequest> PedidoItem { get; set; }
    }
}
