using System;
using System.Collections.Generic;
using AutoMapper;
using TesteDeveloper.Application.Interfaces;
using TesteDeveloper.Application.ViewModels;
using TesteDeveloper.Domain.Core.Bus;
using TesteDeveloper.Domain.Produtos.Repository;
using TesteDeveloper.Domain.Interfaces;
using TesteDeveloper.Domain.Produtos.Commands;

namespace TesteDeveloper.Application.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IUser _user;

        public ProdutoAppService(IBus bus, 
                                IMapper mapper, 
                                IProdutoRepository produtoRepository, 
                                IUser user)
        {
            _bus = bus;
            _mapper = mapper;
            _produtoRepository = produtoRepository;
            _user = user;
        }

        public void Add(ProdutoViewModel produtoViewModel)
        {
            var registroCommand = _mapper.Map<RegistrarProdutoCommand>(produtoViewModel);
            _bus.SendCommand(registroCommand);
        }        

        public ProdutoViewModel GetById(Guid id)
        {
            return _mapper.Map<ProdutoViewModel>(_produtoRepository.GetById(id));
        }

        public IEnumerable<ProdutoViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(_produtoRepository.GetAll());
        }

        public void Update(ProdutoViewModel eventoViewModel)
        {
            // TODO: Validar se o organizador é dono do evento

            var atualizarProdutoCommand = _mapper.Map<AtualizarProdutoCommand>(eventoViewModel);
            _bus.SendCommand(atualizarProdutoCommand);
        }

        public void Remove(Guid id)
        {
            _bus.SendCommand(new ExcluirProdutoCommand(id));
        }

        
        
        public void Dispose()
        {
            _produtoRepository.Dispose();
        }           
    }
}