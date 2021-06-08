using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Eduxcation.Models
{
    public partial class EduxcationContext : DbContext
    {
        public EduxcationContext()
        {
        }

        public EduxcationContext(DbContextOptions<EduxcationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cidade> Cidades { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<PedidoItem> PedidoItems { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<StatusPedido> StatusPedidos { get; set; }
        public virtual DbSet<TipoProduto> TipoProdutos { get; set; }
		public object Produto { get; internal set; }

		/*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=(local);database=Eduxcation;integrated security=yes;");
            }
        }*/

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Cidade>(entity =>
            {
                entity.HasKey(e => e.CodCid)
                    .HasName("PK_Cid");

                entity.ToTable("Cidade");

                entity.Property(e => e.CodCid)
                    .ValueGeneratedNever()
                    .HasColumnName("Cod_Cid");

                entity.Property(e => e.CodEst).HasColumnName("Cod_est");

                entity.Property(e => e.NomeCid)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Nome_Cid");

                entity.HasOne(d => d.CodEstNavigation)
                    .WithMany(p => p.Cidades)
                    .HasForeignKey(d => d.CodEst)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("F_CID_EST");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                /*entity.HasIndex(e => e.Cpf, "KEY_cpf")
                    .IsUnique();*/

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("bairro");

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("cep");

                entity.Property(e => e.CodCid).HasColumnName("Cod_cid");

                entity.Property(e => e.Complemento)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("complemento");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("cpf");

                entity.Property(e => e.DataNascimento)
                    .HasColumnType("datetime")
                    .HasColumnName("data_nascimento");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("endereco");

                entity.Property(e => e.NomeCompleto)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nome_completo");

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("numero");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("telefone");

                entity.HasOne(d => d.CodC)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.CodCid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("F_US_CID");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.CodEst)
                    .HasName("PK_Est");

                entity.ToTable("Estado");

                entity.Property(e => e.CodEst).HasColumnName("Cod_Est");

                entity.Property(e => e.NomeEst)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Nome_Est");

                entity.Property(e => e.SiglaEst)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("sigla_est")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.ToTable("Pedido");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClienteId).HasColumnName("cliente_id");

                entity.Property(e => e.CondicaoPagto)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("condicao_pagto");

                entity.Property(e => e.DataPedido)
                    .HasColumnType("datetime")
                    .HasColumnName("data_pedido");

                entity.Property(e => e.Frete)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("frete");

                entity.Property(e => e.Observacao)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("observacao");

                entity.Property(e => e.QtdProdutos).HasColumnName("qtd_produtos");

                entity.Property(e => e.StatusPedido).HasColumnName("status_pedido");

                entity.Property(e => e.TotalPedido)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("total_pedido");

                entity.Property(e => e.TotalProdutos)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("total_produtos");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("F_pedido_cliente");

                entity.HasOne(d => d.StatusPedidoNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.StatusPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("F_pedido_status");
            });

            modelBuilder.Entity<PedidoItem>(entity =>
            {
                entity.HasKey(e => new { e.PedidoId, e.ProdutoId })
                    .HasName("tb_pedido_item_pkey");

                entity.ToTable("Pedido_item");

                entity.Property(e => e.PedidoId).HasColumnName("pedido_id");

                entity.Property(e => e.ProdutoId).HasColumnName("produto_id");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.PrecoUnitario)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("preco_unitario");

                entity.Property(e => e.QtdProduto).HasColumnName("qtd_produto");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("total");

                entity.HasOne(d => d.Pedido)
                    .WithMany(p => p.PedidoItems)
                    .HasForeignKey(d => d.PedidoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_pedido_item_codigo_pedido_fkey");

                entity.HasOne(d => d.Produto)
                    .WithMany(p => p.PedidoItems)
                    .HasForeignKey(d => d.ProdutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_pedido_item_id_produto_fkey");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("Produto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ano).HasColumnName("ano");

                entity.Property(e => e.Autor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("autor");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.Editora)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("editora");

                entity.Property(e => e.IdTipoProduto).HasColumnName("id_tipo_produto");

                entity.Property(e => e.PrecoVenda)
                    .HasColumnType("decimal(13, 2)")
                    .HasColumnName("preco_venda");

                entity.Property(e => e.SaldoAtual).HasColumnName("saldo_atual");

                entity.Property(e => e.Volume)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("volume");

                entity.HasOne(d => d.IdTipoProdutoNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.IdTipoProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("F_PRODUTO_TIPO");
            });

            modelBuilder.Entity<StatusPedido>(entity =>
            {
                entity.ToTable("Status_Pedido");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.StatusPedido1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("status_pedido");
            });

            modelBuilder.Entity<TipoProduto>(entity =>
            {
                entity.ToTable("Tipo_produto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TipoProduto1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tipo_produto");
            });

            OnModelCreatingPartial(modelBuilder);
        }

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
