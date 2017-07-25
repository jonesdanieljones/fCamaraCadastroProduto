using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.EntityFrameworkCore;
using TesteDeveloper.Domain.Produtos;
using TesteDeveloper.Domain.Produtos.Repository;
using TesteDeveloper.Infra.Data.Context;
using System.Linq.Expressions;

namespace TesteDeveloper.Infra.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ProdutosContext context)
        {
            
        }


        public override IEnumerable<Produto> GetAll()
        {
            var sql = "SELECT * FROM Produto P ";

            return Db.Database.GetDbConnection().Query<Produto>(sql);
        }
        
        public override Produto GetById(Guid id)
        {
            var sql = @"SELECT * FROM Produtos P " +                      
                       " WHERE P.Id = @uid";            

            return Db.Database.GetDbConnection().Query<Produto>(sql).FirstOrDefault();
        }
                        
    }
}