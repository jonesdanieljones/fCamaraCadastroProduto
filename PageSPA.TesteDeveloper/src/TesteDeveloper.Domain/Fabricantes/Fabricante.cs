using System;
using System.Collections.Generic;
using TesteDeveloper.Domain.Core.Models;
using TesteDeveloper.Domain.Produtos;

namespace TesteDeveloper.Domain
{
    public class Fabricante : Entity<Fabricante>
    {
        public Fabricante(Guid id)
        {
            Id = id;
        }
        public string Nome { get; private set; }
        public virtual ICollection<Produto> Produtos { get; set; }
        protected Fabricante() { }
        public override bool EhValido()
        {
            return true;
        }
    }
}