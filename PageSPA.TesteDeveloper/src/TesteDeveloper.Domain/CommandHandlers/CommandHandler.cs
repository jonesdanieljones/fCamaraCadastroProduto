using FluentValidation.Results;
using System;
using TesteDeveloper.Domain.Core.Bus;
using TesteDeveloper.Domain.Core.Notifications;
using TesteDeveloper.Domain.Interfaces;

namespace TesteDeveloper.Domain.CommandHandlers
{
    public abstract class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IBus _bus;
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;
        public CommandHandler(IUnitOfWork uow,
                              IBus bus,
                              IDomainNotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _bus = bus;
            _notifications = notifications;
        }
        protected void NotificarValidacoesErro(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {                
                _bus.RaiseEvent(new DomainNotification(error.PropertyName, error.ErrorMessage));
            }

        }

        protected bool Commit()
        {
            if (_notifications.HasNotifications()) return false;                        
            var commandResponse = _uow.Commit();
            if (commandResponse.Success) return true;
            Console.WriteLine("Ocorreu um erro ao salvar os dados no banco");            
            _bus.RaiseEvent(new DomainNotification("Commit","Ocorreu um erro ao salvar os dados no banco"));
            return false;
        }
    }
}
