using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infra.Contexts.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(60);

            builder.Property(x => x.Preco)
                .IsRequired()
                .HasColumnName("Preco")
                .HasColumnType("DECIMAL")
                .HasMaxLength(60);

            builder.Property(x => x.QuantidadeEstoque)
                .IsRequired()
                .HasColumnName("QuantidadeEstoque")
                .HasColumnType("INT")
                .HasMaxLength(60);

            builder.Property(x => x.ValorTotal)
                .IsRequired()
                .HasColumnName("QuantidadeEstoque")
                .HasColumnType("DECIMAL")
                .HasMaxLength(60);

            builder.Property(x => x.DataCriacao)
                .IsRequired()
                .HasColumnName("DataCriacao")
                .HasColumnType("DATE")
                .HasMaxLength(60);

        }
    }
}