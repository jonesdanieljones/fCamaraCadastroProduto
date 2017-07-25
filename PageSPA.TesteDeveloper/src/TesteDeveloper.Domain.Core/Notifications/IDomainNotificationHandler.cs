using System.Collections.Generic;
using TesteDeveloper.Domain.Core.Events;

namespace TesteDeveloper.Domain.Core.Notifications
{
    public interface IDomainNotificationHandler<T> : IHandler<T> where T : Message
    {
        bool HasNotifications();
        List<T> GetNotifications();
    }
}
