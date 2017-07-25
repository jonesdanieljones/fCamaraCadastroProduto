using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace TesteDeveloper.Application.ViewModels
{
    public class SubCategoriaViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public SelectList SubCategorias()
        {
            return new SelectList(ListarSubCategorias(), "Id", "Nome");
        }

        public List<SubCategoriaViewModel> ListarSubCategorias()
        {
            var subCategoriasList = new List<SubCategoriaViewModel>()
            {
                new SubCategoriaViewModel(){ Id = new Guid("ac381ba8-c187-482c-a5cb-899ad7176137"), Nome = "Congresso"},
                new SubCategoriaViewModel(){ Id = new Guid("1bbfa7e9-5a1f-4cef-b209-58954303dfc3"), Nome = "Meetup"},
                new SubCategoriaViewModel(){ Id = new Guid("d443f7c6-04e5-4f48-8fe0-9e6726b4fdb0"), Nome = "Workshop"}
            };

            return subCategoriasList;
        }
    }
}