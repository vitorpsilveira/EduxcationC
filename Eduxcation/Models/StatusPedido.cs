using System;
using System.Collections.Generic;

#nullable disable

namespace Eduxcation.Models
{
    public partial class StatusPedido
    {
        public StatusPedido()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int Id { get; set; }
        public string StatusPedido1 { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
