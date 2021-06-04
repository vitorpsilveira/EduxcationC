using System;
using System.Collections.Generic;

#nullable disable

namespace Eduxcation.Models
{
    public partial class Cidade
    {
        public Cidade()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int CodCid { get; set; }
        public int CodEst { get; set; }
        public string NomeCid { get; set; }

        public virtual Estado CodEstNavigation { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
