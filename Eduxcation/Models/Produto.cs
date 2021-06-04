using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Eduxcation.Models
{
    public partial class Produto
    {
        public Produto()
        {
            PedidoItems = new HashSet<PedidoItem>();
        }

        public int Id { get; set; }
        public int IdTipoProduto { get; set; }

        [Required(ErrorMessage = "A descrição do produto é obrigatória.")]
        [MaxLength(50, ErrorMessage ="Tamanho maxixmo: 50 caracteres")]
        public string Descricao { get; set; }
        public decimal PrecoVenda { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public string Volume { get; set; }
        public int? Ano { get; set; }
        public int? SaldoAtual { get; set; }

        public virtual TipoProduto IdTipoProdutoNavigation { get; set; }
        public virtual ICollection<PedidoItem> PedidoItems { get; set; }
    }
}
