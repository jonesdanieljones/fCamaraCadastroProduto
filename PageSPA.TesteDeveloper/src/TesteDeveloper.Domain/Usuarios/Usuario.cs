using System;
using System.Collections.Generic;
using TesteDeveloper.Domain.Core.Models;
using TesteDeveloper.Domain.Produtos;

namespace TesteDeveloper.Domain.Usuarios
{
    public class Usuario : Entity<Usuario>
    {
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }

        public Usuario(Guid id, string nome, string cpf, string email)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            Email = email;
        }
        public Usuario(Guid id)
        {
            Id = id;
        }
        // EF Construtor
        protected Usuario() { }

        // EF Propriedade de Navegação
        public virtual ICollection<Produto> Produtos { get; set; }

        public override bool EhValido()
        {
            return true;
        }
    }
}