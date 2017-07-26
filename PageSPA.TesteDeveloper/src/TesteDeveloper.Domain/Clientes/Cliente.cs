using System;
using System.Collections.Generic;
using System.Text;

namespace TesteDeveloper.Domain.Clientes
{
    public class Cliente
    {
        public string NomeFantansia  { get; set; }
        public string RazaoSocial { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Status { get; set; }

    }
}
