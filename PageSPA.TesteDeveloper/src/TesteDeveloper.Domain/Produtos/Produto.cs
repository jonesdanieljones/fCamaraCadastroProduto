using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using TesteDeveloper.Domain.Core.Models;
using TesteDeveloper.Domain.Usuarios;

namespace TesteDeveloper.Domain.Produtos
{
    public class Produto : Entity<Produto>
    {
        private Produto()
        {

        }
        public Produto(string nome,
                       string modelo,
                       int qtdEstoque,
                       int qtdEstoqueMin,
                       bool status
                       )
        {
            Id = Guid.NewGuid();
            Modelo = modelo;
            Nome = nome;            
            QtdEstoque = qtdEstoque;
            QtdEstoqueMin = qtdEstoqueMin;
            Status = status;                        
        }
        public Categoria Categoria { get; private set; }
        public SubCategoria SubCategoria { get; private set; }
        public Fabricante Fabricante { get; private set; }
        public Usuario Usuario { get; private set; }
        public string Modelo { get; private set; }
        public string Nome { get;  private set; }
        public int QtdEstoque { get; private set; }
        public int QtdEstoqueMin { get; private set; }
        public bool Status { get; private set; }
        public Guid? CategoriaId { get; private set; }
        public Guid? SubCategoriaId { get; private set; }
        public Guid? FabricanteId { get; private set; }
        public Guid? UsuarioId { get; private set; }
        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }
        #region Validações
        private void Validar()
        {
            ValidarNome();
            ValidationResult = Validate(this);


        }
        private void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome do produto precisa ser  fornecido.")
                .Length(2, 150).WithMessage("O nome do produto precisa ter  entre 2 e 150 caracteres.");
        }
        #endregion
        public static class ProdutoFactory
        {
            public static Produto NovoProdutoCompleto(Guid id, 
                                                      string modelo, 
                                                      string nome, 
                                                      int qtdEstoque, 
                                                      int qtdEstoqueMin, 
                                                      bool status, 
                                                      Guid? categoriaId, 
                                                      Guid? subCategoriaId,
                                                      Guid? fabricanteId,
                                                      Guid? usuarioId)
            {
                var produto = new Produto()
                {
                    Id = id,
                    Modelo = modelo,
                    Nome = nome,
                    QtdEstoqueMin = qtdEstoqueMin,
                    QtdEstoque = qtdEstoque,
                    Status = status
                };
                if (categoriaId != null)
                {
                    produto.Categoria = new Categoria(categoriaId.Value);
                }
                if (subCategoriaId != null)
                {
                    produto.SubCategoria = new SubCategoria(subCategoriaId.Value);
                }
                if (fabricanteId != null)
                {
                    produto.Fabricante = new Fabricante(fabricanteId.Value);
                }
                if (usuarioId != null)
                {
                    produto.Usuario = new Usuario(usuarioId.Value);
                }
                return produto;
            }

        }
    }   
}
