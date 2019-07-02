using DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.ProductService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProducts();
    }
}