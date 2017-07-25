using System;
using TesteDeveloper.Domain.Core.Events;

namespace TesteDeveloper.Domain.Core.Commands
{
    public class Command : Message
    {
        public DateTime Timestamp { get; private set; }

        public Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
