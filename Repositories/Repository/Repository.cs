using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext ApplicationDbContext;

        public Repository(ApplicationDbContext applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }

        public async Task<T> Get(int id)
        {
            return await ApplicationDbContext.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetAll()
        {
            return ApplicationDbContext.Set<T>();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> findPredicate = null, 
                                   Func<IQueryable<T>, IOrderedQueryable<T>> orderByFunc = null, 
                                   int? count = null)
        {
            IQueryable<T> query = ApplicationDbContext.Set<T>();
            
            if (findPredicate != null)
                query = query.Where(findPredicate);

            if (orderByFunc != null)
                query = orderByFunc(query);

            if (count.HasValue)
                query = query.Take(count.Value);

            return query;
        }

        public async Task Add(T entity)
        {
            await ApplicationDbContext.Set<T>().AddAsync(entity);
        }

        public async Task AddRange(IEnumerable<T> entities)
        {
            await ApplicationDbContext.Set<T>().AddRangeAsync(entities);
        }

        public void Remove(T entity)
        {
            ApplicationDbContext.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            ApplicationDbContext.Set<T>().RemoveRange(entities);
        }

        public async Task Complete()
        {
            await ApplicationDbContext.SaveChangesAsync();
        }
    }
}