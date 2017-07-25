using System;
using TesteDeveloper.Domain.Core.Events;

namespace TesteDeveloper.Domain.Produtos.Events
{
    public class ProdutoRegistradoEvent : BaseProdutoEvent
    {

        public ProdutoRegistradoEvent(
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

            AggregateId = id;
        }
    }
}
