using System;
using System.Collections.Generic;
using System.Text;
using TesteDeveloper.Domain.Core.Models;

namespace TesteDeveloper.Domain.Clientes
{
    public class Cliente : Entity<Cliente>
    {
        public string NomeFantansia  { get; set; }
        public string RazaoSocial { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Status { get; set; }

        public override bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
