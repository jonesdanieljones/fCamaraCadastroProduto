using System;
using System.Collections.Generic;
using System.Text;

namespace TesteDeveloper.Domain.Produtos.Events
{
    public class ProdutoAtualizadoEvent : BaseProdutoEvent
    {
        public ProdutoAtualizadoEvent(
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
