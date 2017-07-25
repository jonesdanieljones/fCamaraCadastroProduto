using TesteDeveloper.Domain.Core.Commands;
using TesteDeveloper.Domain.Interfaces;
using TesteDeveloper.Infra.Data.Context;

namespace TesteDeveloper.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProdutosContext _context;

        public UnitOfWork(ProdutosContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}