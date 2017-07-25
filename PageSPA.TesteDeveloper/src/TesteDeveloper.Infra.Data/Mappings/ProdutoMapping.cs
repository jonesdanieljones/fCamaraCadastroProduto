using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteDeveloper.Domain.Produtos;
using TesteDeveloper.Infra.Data.Extensions;

namespace TesteDeveloper.Infra.Data.Mappings
{
    public class ProdutoMapping : EntityTypeConfiguration<Produto>
    {
        public override void Map(EntityTypeBuilder<Produto> builder)
        {
            builder.Property(e => e.Nome)
               .HasColumnType("varchar(150)")
               .IsRequired();

            builder.Property(e => e.Modelo)
                .HasColumnType("varchar(150)");

            builder.Property(e => e.QtdEstoque)
                .HasColumnType("numeric(29,2)");

            builder.Property(e => e.QtdEstoqueMin)
                .HasColumnType("numeric(29,2)")
                .IsRequired();

            builder.Property(e => e.QtdEstoqueMin)
                .HasColumnType("numeric(29,2)")
                .IsRequired();

            builder.Property(e => e.CategoriaId)
                .HasColumnType("numeric(29,2)")
                .IsRequired();

            builder.Property(e => e.SubCategoriaId)
                .HasColumnType("numeric(29,2)")
                .IsRequired();

            builder.Property(e => e.FabricanteId)
                .HasColumnType("numeric(29,2)")
                .IsRequired();
            
            builder.Ignore(e => e.ValidationResult);
            

            builder.Ignore(e => e.CascadeMode);

            builder.ToTable("Produtos");
           

            builder.HasOne(e => e.Categoria)
                .WithMany(o => o.Produtos)
                .HasForeignKey(e => e.CategoriaId);

            builder.HasOne(e => e.SubCategoria)
                .WithMany(e => e.Produtos)
                .HasForeignKey(e => e.SubCategoriaId)
                .IsRequired(false);
        }
    }
}
