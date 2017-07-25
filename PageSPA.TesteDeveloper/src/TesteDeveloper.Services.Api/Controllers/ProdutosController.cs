using System;
using System.Collections.Generic;
using AutoMapper;
using TesteDeveloper.Application.Interfaces;
using TesteDeveloper.Application.ViewModels;
using TesteDeveloper.Domain.Core.Bus;
using TesteDeveloper.Domain.Core.Notifications;
using TesteDeveloper.Domain.Produtos.Commands;
using TesteDeveloper.Domain.Produtos.Repository;
using TesteDeveloper.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TesteDeveloper.Services.Api.Controllers
{
    public class ProdutosController : BaseController
    {
        private readonly IProdutoAppService _produtoAppService;
        private readonly IBus _bus;
        private readonly IProdutoRepository _produtosRepository;
        private readonly IMapper _mapper;

        public ProdutosController(IDomainNotificationHandler<DomainNotification> notifications, 
                                 IUser user, 
                                 IBus bus, IProdutoAppService produtoAppService, 
                                 IProdutoRepository produtoRepository, 
                                 IMapper mapper) : base(notifications, user, bus)
        {
            _produtoAppService = produtoAppService;
            _produtosRepository = produtoRepository;
            _mapper = mapper;
            _bus = bus;
        }

        [HttpGet]
        [Route("produtos")]
        [AllowAnonymous]
        public IEnumerable<ProdutoViewModel> Get()
        {
            return _produtoAppService.GetAll();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("produtos/{id:guid}")]
        public ProdutoViewModel Get(Guid id, int version)
        {
            return _produtoAppService.GetById(id);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("produtos/categorias")]
        public IEnumerable<CategoriaViewModel> ObterCategorias()
        {
            return _mapper.Map<IEnumerable<CategoriaViewModel>>(_produtoAppService.GetAll());
        }

        [HttpPost]
        [Route("produtos")]
        [Authorize(Policy = "PodeGravar")]
        public IActionResult Post([FromBody]ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotificarErroModelInvalida();
                return Response();
            }

            var produtoCommand = _mapper.Map<RegistrarProdutoCommand>(produtoViewModel);

            _bus.SendCommand(produtoCommand);
            return Response(produtoCommand);
        }

        [HttpPut]
        [Route("produtos")]
        [Authorize(Policy = "PodeGravar")]
        public IActionResult Put([FromBody]ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotificarErroModelInvalida();
                return Response();
            }

            _produtoAppService.Update(produtoViewModel);
            return Response(produtoViewModel);
        }

        [HttpDelete]
        [Route("produtos/{id:guid}")]
        [Authorize(Policy = "PodeGravar")]
        public IActionResult Delete(Guid id)
        {
            _produtoAppService.Remove(id);
            return Response();
        }
    }
}
