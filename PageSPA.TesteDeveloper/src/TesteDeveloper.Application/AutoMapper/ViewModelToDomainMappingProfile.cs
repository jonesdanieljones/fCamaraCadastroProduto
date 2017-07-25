using System;
using AutoMapper;
using TesteDeveloper.Application.ViewModels;
using TesteDeveloper.Domain.Produtos.Repository;
using TesteDeveloper.Domain.Produtos.Commands;

namespace TesteDeveloper.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProdutoViewModel, RegistrarProdutoCommand>()
                .ConstructUsing(c => new RegistrarProdutoCommand(c.Nome, c.Modelo, c.QtdEstoque, c.QtdEstoqueMin, c.Status));
           
            CreateMap<ProdutoViewModel, AtualizarProdutoCommand>()
                .ConstructUsing(c => new AtualizarProdutoCommand(c.Id,c.Nome, c.Modelo, c.QtdEstoque, c.QtdEstoqueMin, c.Status));

            CreateMap<ProdutoViewModel, ExcluirProdutoCommand>()
                .ConstructUsing(c => new ExcluirProdutoCommand(c.Id));
            
        }
    }
}