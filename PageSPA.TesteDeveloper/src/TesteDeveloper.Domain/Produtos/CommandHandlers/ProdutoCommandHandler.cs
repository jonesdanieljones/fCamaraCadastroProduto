using System;
using System.Collections.Generic;
using System.Text;
using TesteDeveloper.Domain.CommandHandlers;
using TesteDeveloper.Domain.Core.Bus;
using TesteDeveloper.Domain.Core.Events;
using TesteDeveloper.Domain.Core.Notifications;
using TesteDeveloper.Domain.Interfaces;
using TesteDeveloper.Domain.Produtos.Commands;
using TesteDeveloper.Domain.Produtos.Events;
using TesteDeveloper.Domain.Produtos.Repository;

namespace TesteDeveloper.Domain.Produtos.CommandHandlers
{
    public class ProdutoCommandHandler : CommandHandler,
        IHandler<RegistrarProdutoCommand>,
        IHandler<AtualizarProdutoCommand>,
        IHandler<ExcluirProdutoCommand>

    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IBus _bus;


        public ProdutoCommandHandler(IProdutoRepository produtoRepository,
                                     IUnitOfWork uow,
                                     IBus bus,
                                     IDomainNotificationHandler<DomainNotification> notifications
                                    ): base(uow, bus, notifications)
        {
            _produtoRepository = produtoRepository;
            _bus = bus;
        }
        public void Handle(RegistrarProdutoCommand message)
        {
            var produto = new Produto(
                message.Nome,
                message.Modelo,
                message.QtdEstoque,
                message.QtdEstoqueMin,
                message.Status
                
                );
            if (!ProdutoValido(produto)) return;                       
            //TODO:
            //Validação de negocio...
            // Persistencia
            _produtoRepository.Add(produto);
            if (Commit())
            {
                Console.WriteLine("Evento Registrado com Sucesso");
                _bus.RaiseEvent(new ProdutoRegistradoEvent(produto.Id, produto.Nome, produto.Modelo, produto.QtdEstoque, produto.QtdEstoqueMin, produto.Status));
            }
        }

        public void Handle(AtualizarProdutoCommand message)
        {
            if (!ProdutoExistente(message.Id, message.MessageType)) return;                        
            
            var produto = Produto.ProdutoFactory.NovoProdutoCompleto(
                                    message.Id,
                                    message.Modelo,
                                    message.Nome,                                    
                                    message.QtdEstoque,
                                    message.QtdEstoqueMin,
                                    message.Status,
                                    null,
                                    null,
                                    null,
                                    null);
            if (!ProdutoValido(produto)) return;
            _produtoRepository.Update(produto);
            if (Commit())
            {
                _bus.RaiseEvent(new ProdutoAtualizadoEvent(produto.Id, produto.Nome, produto.Modelo, produto.QtdEstoque, produto.QtdEstoqueMin, produto.Status));
            }
        }

        public void Handle(ExcluirProdutoCommand message)
        {
            if (!ProdutoExistente(message.Id, message.MessageType)) return;
            _produtoRepository.Remove(message.Id);
            if (Commit())
            {
                _bus.RaiseEvent(new ProdutoExcluidoEvent(message.Id));
            }
        }
        private bool ProdutoValido(Produto produto)
        {
            if (produto.EhValido()) return true;

            NotificarValidacoesErro(produto.ValidationResult);
            return false;
        }
        private bool ProdutoExistente(Guid id, string messageType)
        {
            var produto = _produtoRepository.GetById(id);
            if (produto != null) return true;

            _bus.RaiseEvent(new DomainNotification(messageType, "Produto não encontrado."));
            return false;
        }
    }
}
