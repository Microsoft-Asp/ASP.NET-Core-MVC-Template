using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> Get(int id);
        IQueryable<T> GetAll();
        IQueryable<T> Find(Expression<Func<T, bool>> findPredicate = null, 
                            Func<IQueryable<T>, IOrderedQueryable<T>> orderPredicate = null, 
                            int? count = null);

        Task Add(T entity);
        Task AddRange(IEnumerable<T> entities);

        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

        Task Complete();
    }
}