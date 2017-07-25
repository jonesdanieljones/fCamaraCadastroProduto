using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TesteDeveloper.Domain.Core.Models;
using TesteDeveloper.Domain.Interfaces;
using TesteDeveloper.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;


namespace TesteDeveloper.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<TEntity>
    {
        protected ProdutosContext Db;
        protected DbSet<TEntity> DbSet;
        private ProdutosContext context;

        protected Repository(ProdutosContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public Repository()
        {

        }        

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }
    
        public virtual TEntity GetById(Guid id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(t => t.Id == id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        void IRepository<TEntity>.Add(TEntity obj)
        {
            throw new NotImplementedException();
        }

        TEntity IRepository<TEntity>.GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<TEntity> IRepository<TEntity>.GetAll()
        {
            throw new NotImplementedException();
        }

        void IRepository<TEntity>.Update(TEntity obj)
        {
            throw new NotImplementedException();
        }

        void IRepository<TEntity>.Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<TEntity> IRepository<TEntity>.Find(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }
    }
}