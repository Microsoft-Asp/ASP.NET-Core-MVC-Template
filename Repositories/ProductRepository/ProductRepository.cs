using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.ProductRepository
{
    public class ProductRepository : Repository.Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public async Task<IEnumerable<Product>> GetProductsWithCategories(int? pageIndex = null, int? pageSize = null)
        {
            var products = GetAll();
            if (pageSize.HasValue && pageIndex.HasValue)
            {
                products = products.Skip((pageIndex.Value - 1) * pageSize.Value)
                                   .Take(pageSize.Value);
            }
            
            return await products.Include(p => p.ProductCategory)
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetCheapestProducts(int Count)
        {
            return await Find(null, predicate => predicate.OrderBy(order => order.Price), Count)
                                                          .AsNoTracking()
                                                          .ToListAsync();
        }
    }
}