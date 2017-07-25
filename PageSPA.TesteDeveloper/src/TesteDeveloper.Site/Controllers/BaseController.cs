
using System;
using Microsoft.AspNetCore.Mvc;
using TesteDeveloper.Domain.Core.Notifications;
using TesteDeveloper.Domain.Interfaces;

namespace TesteDeveloper.Site.Controllers
{
    public class BaseController : Controller
    {
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;
        private readonly IUser _user;

        public Guid OrganizadorId { get; set; }

        public BaseController(IDomainNotificationHandler<DomainNotification> notifications, 
                              IUser user)
        {
            _notifications = notifications;
            _user = user;

            if (_user.IsAuthenticated())
            {
                OrganizadorId = _user.GetUserId();
            }
        }

        protected bool OperacaoValida()
        {
            return (!_notifications.HasNotifications());
        }
    }
}
