using TesteDeveloper.Domain.Core.Events;
using TesteDeveloper.Domain.Organizadores.Events;

namespace Eventos.IO.Domain.Organizadores.Events
{
    public class UsuarioEventHandler :
        IHandler<UsuarioRegistradoEvent>
    {
        public void Handle(UsuarioRegistradoEvent message)
        {
            // TODO: Enviar um email?
        }
    }
}