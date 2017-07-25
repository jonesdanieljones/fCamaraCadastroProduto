using System;
using System.Collections.Generic;
using System.Text;
using TesteDeveloper.Domain.Core.Events;

namespace TesteDeveloper.Domain.Produtos.Events
{
    public abstract class BaseProdutoEvent : Event
    {
        public Guid Id { get; protected set; }
        public string Modelo { get; protected set; }
        public string Nome { get; protected set; }
        public int QtdEstoque { get; protected set; }
        public int QtdEstoqueMin { get; protected set; }
        public bool Status { get; protected set; }
    }
}
