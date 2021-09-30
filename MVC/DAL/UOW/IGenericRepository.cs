using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MVC.DAL.UOW
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        //List<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
        //    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        //    string includeProperties = "", int page = 1, int pageSize = 2);

        //Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
        //    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        //    string includeProperties = "", int page = 1, int pageSize = 20);

        TEntity GetByID(object id);
    }
}
