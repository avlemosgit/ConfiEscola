using System;
using Microsoft.EntityFrameworkCore;
using ConfiEscola.Domain.Interfaces.Data;
using ConfiEscola.Infra.Data.Context;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConfiEscola.Infra.Data.Configuration
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ConfiEscolaContext _dbContext;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(ConfiEscolaContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = _dbContext.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        { 
            DbSet.Add(obj);
        }

        public virtual void Update(TEntity obj)
        { 
            DbSet.Update(obj);
        }
        public virtual void Remove(TEntity obj) 
        {
            DbSet.Remove(obj);
        }
        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
