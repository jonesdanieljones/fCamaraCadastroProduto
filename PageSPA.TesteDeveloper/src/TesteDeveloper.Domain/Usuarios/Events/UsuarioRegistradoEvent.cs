using System;
using TesteDeveloper.Domain.Core.Events;

namespace TesteDeveloper.Domain.Organizadores.Events
{
    public class UsuarioRegistradoEvent : Event
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }

        public UsuarioRegistradoEvent(Guid id, string nome, string cpf, string email)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            Email = email;
        }
    }
}