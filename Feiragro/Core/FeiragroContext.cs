using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Core;

public partial class FeiragroContext : DbContext
{
    public FeiragroContext()
    {
    }

    public FeiragroContext(DbContextOptions<FeiragroContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Associacao> Associacaos { get; set; }

    public virtual DbSet<Feira> Feiras { get; set; }

    public virtual DbSet<Pessoa> Pessoas { get; set; }

    public virtual DbSet<Pontoassociacao> Pontoassociacaos { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    public virtual DbSet<Produtofeira> Produtofeiras { get; set; }

    public virtual DbSet<Produtovendum> Produtovenda { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Reservaprodutofeira> Reservaprodutofeiras { get; set; }

    public virtual DbSet<Tipoproduto> Tipoprodutos { get; set; }

    public virtual DbSet<Vendum> Venda { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=123456;database=Feiragro");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Associacao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("associacao");

            entity.HasIndex(e => e.Cnpj, "idx_cnpj");

            entity.HasIndex(e => e.Nome, "idx_nome");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Cnpj)
                .HasMaxLength(15)
                .HasColumnName("cnpj");
            entity.Property(e => e.Data)
                .HasColumnType("datetime")
                .HasColumnName("data");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Endereco)
                .HasMaxLength(50)
                .HasColumnName("endereco");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'ATIVO'")
                .HasColumnType("enum('ATIVO','DESATIVO')")
                .HasColumnName("status");
            entity.Property(e => e.Telefone)
                .HasMaxLength(14)
                .HasColumnName("telefone");
        });

        modelBuilder.Entity<Feira>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("feira");

            entity.HasIndex(e => e.IdAssociacao, "fk_Feira_Associacao1_idx");

            entity.HasIndex(e => e.IdPontoAssociacao, "fk_Feira_PontoAssociacao1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DataFim)
                .HasColumnType("date")
                .HasColumnName("dataFim");
            entity.Property(e => e.DataInicio)
                .HasColumnType("date")
                .HasColumnName("dataInicio");
            entity.Property(e => e.IdAssociacao).HasColumnType("int(11)");
            entity.Property(e => e.IdPontoAssociacao).HasColumnType("int(11)");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'ABERTA'")
                .HasColumnType("enum('FECHADA','CANCELADA','ABERTA')")
                .HasColumnName("status");

            entity.HasOne(d => d.IdAssociacaoNavigation).WithMany(p => p.Feiras)
                .HasForeignKey(d => d.IdAssociacao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Feira_Associacao1");

            entity.HasOne(d => d.IdPontoAssociacaoNavigation).WithMany(p => p.Feiras)
                .HasForeignKey(d => d.IdPontoAssociacao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Feira_PontoAssociacao1");
        });

        modelBuilder.Entity<Pessoa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pessoa");

            entity.HasIndex(e => e.IdAssociacao, "fk_Pessoa_Associacao1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .HasColumnName("cpf");
            entity.Property(e => e.DataNascimento)
                .HasColumnType("date")
                .HasColumnName("dataNascimento");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.IdAssociacao).HasColumnType("int(11)");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
            entity.Property(e => e.Telefone)
                .HasMaxLength(14)
                .HasColumnName("telefone");
            entity.Property(e => e.TipoPessoa)
                .HasDefaultValueSql("'C'")
                .HasColumnType("enum('A','D','P','C')")
                .HasColumnName("tipoPessoa");

            entity.HasOne(d => d.IdAssociacaoNavigation).WithMany(p => p.Pessoas)
                .HasForeignKey(d => d.IdAssociacao)
                .HasConstraintName("fk_Pessoa_Associacao1");
        });

        modelBuilder.Entity<Pontoassociacao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pontoassociacao");

            entity.HasIndex(e => e.IdAssociacao, "fk_PontoAssociacao_Associacao1_idx");

            entity.HasIndex(e => e.Bairro, "idx_bairro");

            entity.HasIndex(e => e.Municipio, "idx_municipio");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Bairro)
                .HasMaxLength(50)
                .HasColumnName("bairro");
            entity.Property(e => e.Cep)
                .HasMaxLength(8)
                .HasColumnName("cep");
            entity.Property(e => e.Complemento)
                .HasMaxLength(80)
                .HasColumnName("complemento");
            entity.Property(e => e.IdAssociacao).HasColumnType("int(11)");
            entity.Property(e => e.Municipio)
                .HasMaxLength(20)
                .HasColumnName("municipio");
            entity.Property(e => e.Numero)
                .HasColumnType("int(11)")
                .HasColumnName("numero");
            entity.Property(e => e.Rua)
                .HasMaxLength(50)
                .HasColumnName("rua");
            entity.Property(e => e.Uf)
                .HasMaxLength(2)
                .HasColumnName("uf");

            entity.HasOne(d => d.IdAssociacaoNavigation).WithMany(p => p.Pontoassociacaos)
                .HasForeignKey(d => d.IdAssociacao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_PontoAssociacao_Associacao1");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("produto");

            entity.HasIndex(e => e.IdTipoProduto, "fk_Produto_TipoProduto1_idx");

            entity.HasIndex(e => e.Nome, "idx_nome");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.IdTipoProduto).HasColumnType("int(11)");
            entity.Property(e => e.Imagem)
                .HasColumnType("blob")
                .HasColumnName("imagem");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");

            entity.HasOne(d => d.IdTipoProdutoNavigation).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.IdTipoProduto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Produto_TipoProduto1");
        });

        modelBuilder.Entity<Produtofeira>(entity =>
        {
            entity.HasKey(e => new { e.IdFeira, e.IdProduto }).HasName("PRIMARY");

            entity.ToTable("produtofeira");

            entity.HasIndex(e => e.IdFeira, "fk_ProdutoFeira_Feira1_idx");

            entity.HasIndex(e => e.IdProduto, "fk_ProdutoFeira_Produto1_idx");

            entity.Property(e => e.IdFeira).HasColumnType("int(11)");
            entity.Property(e => e.IdProduto).HasColumnType("int(11)");
            entity.Property(e => e.JustificativaReserva)
                .HasMaxLength(80)
                .HasColumnName("justificativaReserva");
            entity.Property(e => e.QuantidadeAjuste)
                .HasColumnType("int(11)")
                .HasColumnName("quantidadeAjuste");
            entity.Property(e => e.QuantidadeDisponivel)
                .HasColumnType("int(11)")
                .HasColumnName("quantidadeDisponivel");
            entity.Property(e => e.QuantidadeVendida)
                .HasColumnType("int(11)")
                .HasColumnName("quantidadeVendida");
            entity.Property(e => e.UnidadeMedida)
                .HasColumnType("enum('KG','LITRO','MOLHO','GRAMA','CACHO','UNIDADE')")
                .HasColumnName("unidadeMedida");
            entity.Property(e => e.Valor)
                .HasPrecision(6)
                .HasColumnName("valor");

            entity.HasOne(d => d.IdFeiraNavigation).WithMany(p => p.Produtofeiras)
                .HasForeignKey(d => d.IdFeira)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ProdutoFeira_Feira1");

            entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.Produtofeiras)
                .HasForeignKey(d => d.IdProduto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ProdutoFeira_Produto1");
        });

        modelBuilder.Entity<Produtovendum>(entity =>
        {
            entity.HasKey(e => new { e.IdFeira, e.IdProduto, e.IdVenda }).HasName("PRIMARY");

            entity.ToTable("produtovenda");

            entity.HasIndex(e => new { e.IdFeira, e.IdProduto }, "fk_ProdutoFeira_has_Venda_ProdutoFeira1_idx");

            entity.HasIndex(e => e.IdVenda, "fk_ProdutoFeira_has_Venda_Venda1_idx");

            entity.Property(e => e.IdFeira).HasColumnType("int(11)");
            entity.Property(e => e.IdProduto).HasColumnType("int(11)");
            entity.Property(e => e.IdVenda).HasColumnType("int(11)");
            entity.Property(e => e.Quantidade)
                .HasPrecision(10)
                .HasColumnName("quantidade");

            entity.HasOne(d => d.IdVendaNavigation).WithMany(p => p.Produtovenda)
                .HasForeignKey(d => d.IdVenda)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_ProdutoFeira_has_Venda_Venda1");

            entity.HasOne(d => d.Id).WithMany(p => p.Produtovenda)
                .HasForeignKey(d => new { d.IdFeira, d.IdProduto })
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_ProdutoFeira_has_Venda_ProdutoFeira1");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("reserva");

            entity.HasIndex(e => e.IdPessoa, "fk_Reserva_Pessoa1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Data)
                .HasColumnType("datetime")
                .HasColumnName("data");
            entity.Property(e => e.IdPessoa).HasColumnType("int(11)");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'PENDENTE'")
                .HasColumnType("enum('PENDENTE','CANCELADO','ACEITADO')")
                .HasColumnName("status");

            entity.HasOne(d => d.IdPessoaNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdPessoa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Reserva_Pessoa1");
        });

        modelBuilder.Entity<Reservaprodutofeira>(entity =>
        {
            entity.HasKey(e => new { e.IdReserva, e.IdFeira, e.IdProduto }).HasName("PRIMARY");

            entity.ToTable("reservaprodutofeira");

            entity.HasIndex(e => new { e.IdFeira, e.IdProduto }, "fk_Reserva_has_ProdutoFeira_ProdutoFeira1_idx");

            entity.HasIndex(e => e.IdReserva, "fk_Reserva_has_ProdutoFeira_Reserva1_idx");

            entity.Property(e => e.IdReserva).HasColumnType("int(11)");
            entity.Property(e => e.IdFeira).HasColumnType("int(11)");
            entity.Property(e => e.IdProduto).HasColumnType("int(11)");
            entity.Property(e => e.ReservaHasProdutoFeiracol)
                .HasPrecision(10)
                .HasColumnName("Reserva_has_ProdutoFeiracol");

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.Reservaprodutofeiras)
                .HasForeignKey(d => d.IdReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Reserva_has_ProdutoFeira_Reserva1");

            entity.HasOne(d => d.Id).WithMany(p => p.Reservaprodutofeiras)
                .HasForeignKey(d => new { d.IdFeira, d.IdProduto })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Reserva_has_ProdutoFeira_ProdutoFeira1");
        });

        modelBuilder.Entity<Tipoproduto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tipoproduto");

            entity.HasIndex(e => e.Nome, "idx_nome");

            entity.HasIndex(e => e.Nome, "nome_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Vendum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("venda");

            entity.HasIndex(e => e.IdCliente, "fk_Venda_Pessoa1_idx");

            entity.HasIndex(e => e.IdProdutor, "fk_Venda_Pessoa2_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DataVenda).HasColumnType("datetime");
            entity.Property(e => e.IdCliente).HasColumnType("int(11)");
            entity.Property(e => e.IdProdutor).HasColumnType("int(11)");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.VendumIdClienteNavigations)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Venda_Pessoa1");

            entity.HasOne(d => d.IdProdutorNavigation).WithMany(p => p.VendumIdProdutorNavigations)
                .HasForeignKey(d => d.IdProdutor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Venda_Pessoa2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
