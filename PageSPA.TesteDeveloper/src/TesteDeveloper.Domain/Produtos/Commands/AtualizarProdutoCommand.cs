using System;
using TesteDeveloper.Domain.Produtos.Commands;

namespace TesteDeveloper.Domain.Produtos.Repository
{
    public class AtualizarProdutoCommand : BaseProdutoCommand
    {
        public AtualizarProdutoCommand(
                       Guid id,
                       string nome,
                       string modelo,
                       int qtdEstoque,
                       int qtdEstoqueMin,
                       bool status
                       )
        {
            Id = id;
            Modelo = modelo;
            Nome = nome;
            QtdEstoque = qtdEstoque;
            QtdEstoqueMin = qtdEstoqueMin;
            Status = status;
        }
    }
}
