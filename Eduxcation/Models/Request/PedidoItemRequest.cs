using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduxcation.Models.Request
{
	public class PedidoItemRequest
	{

        public int ProdutoId { get; set; }
        public int QtdProduto { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Total { get; set; }

    }
}
