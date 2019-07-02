using Models;
using Repositories.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.ProductRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsWithCategories(int? pageIndex = null, int? pageSize = null);
        Task<IEnumerable<Product>> GetCheapestProducts(int Count);
    }
}