using AutoMapper;
using TesteDeveloper.Application.ViewModels;
using TesteDeveloper.Domain;
using TesteDeveloper.Domain.Produtos;

namespace TesteDeveloper.IO.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Produto, ProdutoViewModel>();
            CreateMap<Categoria, CategoriaViewModel>();
            CreateMap<SubCategoria, SubCategoriaViewModel>();            
        }
    }
}