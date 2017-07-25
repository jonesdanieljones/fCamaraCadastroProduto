using System;
using System.Collections.Generic;
using TesteDeveloper.Domain.Core.Models;

namespace TesteDeveloper.Domain.Produtos
{
    public class Categoria : Entity<Categoria>
    {
        public Categoria(Guid id)
        {
            Id = id;
        }
        public string Nome { get; private set; }
       
        public virtual ICollection<Produto> Produtos { get; set; }
        protected Categoria() { }
        public override bool EhValido()
        {
            return true;
        }
    }
}