﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Eduxcation.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public int CodCid { get; set; }
        public string Cep { get; set; }

        public virtual Cidade CodC { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
