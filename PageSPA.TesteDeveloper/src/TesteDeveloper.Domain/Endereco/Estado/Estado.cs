
using System;
using TesteDeveloper.Domain.Core.Models;

namespace TesteDeveloper.Domain.Endereco.Estado
{
    public class Estado : Entity<Estado>
    {
        public string Nome  { get; set; }

        public override bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
