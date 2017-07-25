using TesteDeveloper.Domain.Core.Commands;
using TesteDeveloper.Domain.Core.Events;

namespace TesteDeveloper.Domain.Core.Bus
{
    public interface IBus
    {
        void SendCommand<T>(T theCommand) where T : Command;
        void RaiseEvent<T>(T theEvent) where T : Event;

    }
}
