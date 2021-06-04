using System;
using System.Collections.Generic;

#nullable disable

namespace Eduxcation.Models
{
    public partial class TipoProduto
    {
        public TipoProduto()
        {
            Produtos = new HashSet<Produto>();
        }

        public int Id { get; set; }
        public string TipoProduto1 { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
