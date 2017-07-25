using System;
using System.Collections.Generic;
using TesteDeveloper.Domain.Core.Models;

namespace TesteDeveloper.Domain.Produtos
{
    public class SubCategoria : Entity<SubCategoria>
    {
        public SubCategoria(Guid id)
        {
            Id = id;
        }
        public string Nome { get; private set; }
        public virtual ICollection<Produto> Produtos { get; set; }
        protected SubCategoria() { }
        public override bool EhValido()
        {
            return true;
        }
    }
}