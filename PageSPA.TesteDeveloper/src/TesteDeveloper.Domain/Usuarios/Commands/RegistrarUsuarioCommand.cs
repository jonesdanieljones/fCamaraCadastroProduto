using System;
using TesteDeveloper.Domain.Core.Commands;

namespace TesteDeveloper.Domain.Usuarios.Commands
{
    public class RegistrarUsuarioCommand : Command
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }

        public RegistrarUsuarioCommand(Guid id, string nome, string cpf, string email)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            Email = email;
        }
    }
}