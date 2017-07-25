using TesteDeveloper.Domain.Produtos.Commands;

namespace TesteDeveloper.Domain.Produtos.Repository
{
    public class RegistrarProdutoCommand : BaseProdutoCommand
    {
        public RegistrarProdutoCommand(string nome,
                       string modelo,
                       int qtdEstoque,
                       int qtdEstoqueMin,
                       bool status)
        {
            Nome = nome;
            Modelo = modelo;
            
            QtdEstoque = qtdEstoque;
            QtdEstoqueMin = qtdEstoqueMin;
            Status = status;

            
        }

    }
}
