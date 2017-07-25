using System;
using System.ComponentModel.DataAnnotations;
using TesteDeveloper.Application.ViewModels;

namespace TesteDeveloper.Application.ViewModels
{
    public class ProdutoViewModel
    {
        public ProdutoViewModel(string nome,
                                string modelo,
                                int qtdEstoque,
                                int qtdEstoqueMin,
                                bool status)
        {

            Id = Guid.NewGuid();
            Modelo = modelo;
            Nome = nome;
            QtdEstoque = qtdEstoque;
            QtdEstoqueMin = qtdEstoqueMin;
            Status = status;
            Categoria = new CategoriaViewModel();
            SubCategoria = new SubCategoriaViewModel();
        }
        [Key]
        public Guid Id { get; set; }

        public CategoriaViewModel Categoria { get; private set; }
        public SubCategoriaViewModel SubCategoria { get; private set; }
        public FabricanteViewModel Fabricante { get; private set; }
        [Required(ErrorMessage = "O Modelo é requerido")]
        [MinLength(2, ErrorMessage = "O tamanho minimo do Nome é {1}")]
        [MaxLength(150, ErrorMessage = "O tamanho máximo do Nome é {1}")]
        [Display(Name = "Modelo do Produto")]
        public string Modelo { get; private set; }
        [Required(ErrorMessage = "O Nome é requerido")]
        [MinLength(2, ErrorMessage = "O tamanho minimo do Nome é {1}")]
        [MaxLength(150, ErrorMessage = "O tamanho máximo do Nome é {1}")]
        [Display(Name = "Nome do Produto")]
        public string Nome { get; private set; }
        public int QtdEstoque { get; private set; }
        public int QtdEstoqueMin { get; private set; }
        public bool Status { get; private set; }
        public Guid? CategoriaId { get; private set; }
        public Guid? SubCategoriaId { get; private set; }
        public Guid? FabricanteId { get; private set; }
        
    }
}