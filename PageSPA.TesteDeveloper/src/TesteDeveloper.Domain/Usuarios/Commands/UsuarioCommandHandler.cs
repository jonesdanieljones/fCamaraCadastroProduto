using System;
using System.Linq;
using TesteDeveloper.Domain.CommandHandlers;
using TesteDeveloper.Domain.Core.Bus;
using TesteDeveloper.Domain.Core.Events;
using TesteDeveloper.Domain.Core.Notifications;
using TesteDeveloper.Domain.Interfaces;
using TesteDeveloper.Domain.Organizadores.Events;
using TesteDeveloper.Domain.Usuarios;
using TesteDeveloper.Domain.Usuarios.Commands;
using TesteDeveloper.Domain.Usuarios.Repository;

namespace TesteDeveloper.Domain.Usuarioes.Commands
{
    public class UsuarioCommandHandler : CommandHandler,
        IHandler<RegistrarUsuarioCommand>
    {
        private readonly IBus _bus;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioCommandHandler(
            IUnitOfWork uow, 
            IBus bus, 
            IDomainNotificationHandler<DomainNotification> notifications, 
            IUsuarioRepository usuarioRepository) : base(uow, bus, notifications)
        {
            _bus = bus;
            _usuarioRepository = usuarioRepository;
        }

        public void Handle(RegistrarUsuarioCommand message)
        {
            var usuario = new Usuario(message.Id,message.Nome,message.CPF,message.Email);

            if (!usuario.EhValido())
            {
                NotificarValidacoesErro(usuario.ValidationResult);
                return;
            }

            var usuarioExistente = _usuarioRepository.Find(o => o.CPF == usuario.CPF || o.Email == usuario.Email);

            if (usuarioExistente.Any())
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "CPF ou e-mail já utilizados"));
            }

            _usuarioRepository.Add(usuario);

            if (Commit())
            {
                _bus.RaiseEvent(new UsuarioRegistradoEvent(usuario.Id,usuario.Nome, usuario.CPF, usuario.Email));
            }
        }
    }
}