using System;
using System.Collections.Generic;

#nullable disable

namespace Eduxcation.Models
{
    public partial class PedidoItem
    {
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public int QtdProduto { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Total { get; set; }
        public int Id { get; set; }

        public virtual Pedido Pedido { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
