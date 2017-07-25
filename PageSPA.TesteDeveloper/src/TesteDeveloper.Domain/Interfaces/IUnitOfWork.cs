using System;
using TesteDeveloper.Domain.Core.Commands;

namespace TesteDeveloper.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
