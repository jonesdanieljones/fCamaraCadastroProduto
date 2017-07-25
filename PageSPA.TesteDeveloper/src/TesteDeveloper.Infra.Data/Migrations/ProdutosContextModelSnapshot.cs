using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TesteDeveloper.Infra.Data.Context;

namespace TesteDeveloper.Infra.Data.Migrations
{
    [DbContext(typeof(ProdutosContext))]
    partial class ProdutosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TesteDeveloper.Domain.Produtos.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("TesteDeveloper.Domain.Produtos.SubCategoria", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<string>("Nome")
                    .IsRequired()
                    .HasColumnType("varchar(150)");

                b.HasKey("Id");

                b.ToTable("SubCategorias");
            });
            
            modelBuilder.Entity("TesteDeveloper.Domain.Produtos.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CategoriaId");

                    b.Property<Guid?>("SubCategoriaId");                   

                    b.Property<string>("Modelo")
                        .HasColumnType("varchar(150)");
                 
                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<int>("qtdEstoque")                        
                        .HasColumnType("numeric(29,0)");

                    b.Property<int>("qtdEstoqueMin")
                        .HasColumnType("numeric(29,0)");
                    
                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("SubCategoriaId");

                    b.ToTable("Produtos");
                });
         
            modelBuilder.Entity("TesteDeveloper.Domain.Produtos.Produto", b =>
                {
                    b.HasOne("TesteDeveloper.Domain.Produtos.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaId");
                });
        }
    }
}
