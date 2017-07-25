using System;

namespace TesteDeveloper.Domain.Produtos.Commands
{
    public class ExcluirProdutoCommand : BaseProdutoCommand
    {
        public ExcluirProdutoCommand(Guid id)
        {
            Id = id;
            AggregateId = Id;
        }
    }
}
