using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TesteDeveloper.Domain;
using TesteDeveloper.Infra.Data.Extensions;

namespace TesteDeveloper.Infra.Data.Mappings
{
    public class FabricanteMapping : EntityTypeConfiguration<Fabricante>
    {
        public override void Map(EntityTypeBuilder<Fabricante> builder)
        {
            builder.Property(e => e.Nome)
               .HasColumnType("varchar(150)")
               .IsRequired();

            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(e => e.CascadeMode);

            builder.ToTable("Fabricantes");
        }
    }
}
