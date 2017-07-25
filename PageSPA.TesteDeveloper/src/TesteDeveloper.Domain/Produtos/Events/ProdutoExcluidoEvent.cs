using System;
using System.Collections.Generic;
using System.Text;

namespace TesteDeveloper.Domain.Produtos.Events
{
    public class ProdutoExcluidoEvent : BaseProdutoEvent
    {
        public ProdutoExcluidoEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
           
        }
    }
}
