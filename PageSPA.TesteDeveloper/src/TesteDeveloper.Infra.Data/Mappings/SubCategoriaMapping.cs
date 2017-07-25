using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteDeveloper.Domain.Produtos;
using TesteDeveloper.Infra.Data.Extensions;

namespace TesteDeveloper.Infra.Data.Mappings
{
    public class SubCategoriaMapping : EntityTypeConfiguration<SubCategoria>
    {
        public override void Map(EntityTypeBuilder<SubCategoria> builder)
        {
            builder.Property(e => e.Nome)
               .HasColumnType("varchar(150)")
               .IsRequired();

            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(e => e.CascadeMode);

            builder.ToTable("SubCategorias");
        }
    }
}
