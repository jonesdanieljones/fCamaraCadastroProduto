
using System;
using System.Collections.Generic;
using TesteDeveloper.Application.ViewModels;

namespace TesteDeveloper.Application.Interfaces
{
    public interface IProdutoAppService : IDisposable
    {
        void Add(ProdutoViewModel produtoViewModel);
        IEnumerable<ProdutoViewModel> GetAll();        
        ProdutoViewModel GetById(Guid id);
        void Update(ProdutoViewModel produtoViewModel);
        void Remove(Guid id);        
    }
}