using DTOs;
using Repositories.ProductRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            return (await _productRepository.GetProductsWithCategories()).Select(model => new ProductDto
            {
                Id = model.ProductId,
                Name = model.Name,
                Price = model.Price,
                ProductCategory = new ProductCategoryDto
                {
                    Id = model.ProductCategory.CategoryId,
                    Name = model.ProductCategory.Name,
                }
            });
        }
    }
}