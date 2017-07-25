using System;
using TesteDeveloper.Domain.Core.Commands;

namespace TesteDeveloper.Domain.Produtos.Commands
{
    public abstract class  BaseProdutoCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Modelo { get; protected set; }
        public string Nome { get; protected set; }
        public int QtdEstoque { get; protected set; }
        public int QtdEstoqueMin { get; protected set; }
        public bool Status { get; protected set; }

    }
}
