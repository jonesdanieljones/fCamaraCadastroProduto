using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using TesteDeveloper.Application.Interfaces;
using TesteDeveloper.Application.ViewModels;
using TesteDeveloper.Domain.Core.Notifications;
using TesteDeveloper.Domain.Interfaces;

namespace TesteDeveloper.Site.Controllers
{
    [Route("")]
    public class ProdutosController : BaseController
    {
        private readonly IProdutoAppService _produtoAppService;
        
        public ProdutosController(IProdutoAppService produtoAppService,
                                 IDomainNotificationHandler<DomainNotification> notifications,
                                 IUser user) : base(notifications, user)
        {
            _produtoAppService = produtoAppService;
        }

        [Route("")]
        [Route("proximos-produtos")]
        public IActionResult Index()
        {
            return View(_produtoAppService.GetAll());
        }

        [Route("meus-produtos")]
        [Authorize(Policy = "PodeLerProdutos")]
        public IActionResult MeusProdutos()
        {
            return View(_produtoAppService.GetById(OrganizadorId));
        }

        [Route("dados-do-produto/{id:guid}")]
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoViewModel = _produtoAppService.GetById(id.Value);

            if (produtoViewModel == null)
            {
                return NotFound();
            }

            return View(produtoViewModel);
        }

        [Route("novo-produto")]
        [Authorize(Policy = "PodeGravar")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("novo-produto")]
        [Authorize(Policy = "PodeGravar")]
        public IActionResult Create(ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid) return View(produtoViewModel);

             produtoViewModel.OrganizadorId = OrganizadorId;
            _produtoAppService.Add(produtoViewModel);

            ViewBag.RetornoPost = OperacaoValida() ? "success,Evento registrado com sucesso!" : "error,Evento não registrado! Verifique as mensagens";

            return View(produtoViewModel);
        }

        [Route("editar-produto/{id:guid}")]
        [Authorize(Policy = "PodeGravar")]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoViewModel = _produtoAppService.GetById(id.Value);

            if (produtoViewModel == null)
            {
                return NotFound();
            }

            if (ValidarAutoridadeProduto(produtoViewModel))
            {
                return RedirectToAction("MeusProdutos", _produtoAppService.GetById(OrganizadorId));
            }

            return View(produtoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("editar-produto/{id:guid}")]
        [Authorize(Policy = "PodeGravar")]
        public IActionResult Edit(ProdutoViewModel produtoViewModel)
        {
            if (ValidarAutoridadeProduto(produtoViewModel))
            {
                return RedirectToAction("MeusProdutos", _produtoAppService.GetById(OrganizadorId));
            }

            if (!ModelState.IsValid) return View(produtoViewModel);

            produtoViewModel.OrganizadorId = OrganizadorId;
            _produtoAppService.Update(produtoViewModel);

            ViewBag.RetornoPost = OperacaoValida() ? "success,Produto atualizado com sucesso!" : "error,Produto não ser atualizado! Verifique as mensagens";
        
            return View(produtoViewModel);
        }

        [Authorize(Policy = "PodeGravar")]
        [Route("excluir-produto/{id:guid}")]
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoViewModel = _produtoAppService.GetById(id.Value);

            if (ValidarAutoridadeProduto(produtoViewModel))
            {
                return RedirectToAction("MeusProdutos", _produtoAppService.GetById(OrganizadorId));
            }

            if (produtoViewModel == null)
            {
                return NotFound();
            }

            return View(produtoViewModel);
        }

        [Authorize(Policy = "PodeGravar")]
        [HttpPost, ActionName("Delete")]
        [Route("excluir-evento/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            if (ValidarAutoridadeProduto(_produtoAppService.GetById(id)))
            {
                return RedirectToAction("MeusProdutos", _produtoAppService.GetById(OrganizadorId));
            }

            _produtoAppService.Remove(id);
            return RedirectToAction("Index");
        }              

        private bool ValidarAutoridadeProduto(ProdutoViewModel produtoViewModel)
        {
            return produtoViewModel.OrganizadorId != OrganizadorId;
        }

    }
}

