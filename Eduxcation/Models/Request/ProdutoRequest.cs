using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduxcation.Models.Request
{
	public class ProdutoRequest
	{
        public int IdTipoProduto { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoVenda { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public string Volume { get; set; }
        public int? Ano { get; set; }
        public int? SaldoAtual { get; set; }
    }
}
