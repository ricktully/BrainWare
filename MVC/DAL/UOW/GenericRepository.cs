using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.DAL.UOW
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal BrainwareContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(BrainwareContext context)
        {
            this.context = context;
            //context.Configuration.LazyLoadingEnabled = false;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual TEntity GetByID(object id)
        {
            var entity = dbSet.Find(id);

            return entity;
        }
    }
}
