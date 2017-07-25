using System;
using System.Collections.Generic;
using System.Text;
using TesteDeveloper.Domain.Core.Events;
using TesteDeveloper.Domain.Produtos.Events;

namespace TesteDeveloper.Domain.Produtos.EventHandlers
{
    public class ProdutoEventHandler :
            IHandler<ProdutoRegistradoEvent>,
            IHandler<ProdutoAtualizadoEvent>,
            IHandler<ProdutoExcluidoEvent>
    {
        public void Handle(ProdutoRegistradoEvent message)
        {
            //Enviar um e-mail
        }

        public void Handle(ProdutoAtualizadoEvent message)
        {
            //Enviar um e-mail
        }

        public void Handle(ProdutoExcluidoEvent message)
        {
            //Enviar um e-mail
        }
    }
}
