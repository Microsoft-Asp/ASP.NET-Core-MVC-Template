using Microsoft.AspNetCore.Mvc;
using Services.ProductService;
using System.Diagnostics;
using System.Threading.Tasks;
using Template.Models;
using Template.ViewModels;
using Utilities.Attributes.Filters;

namespace Template.Controllers
{
    public class HomeController : Controller
    {
        IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var productsDto = await _productService.GetAllProducts();
            var viewModel = new HomeViewModel
            {
                Products = productsDto
            };
            return View(viewModel);
        }

        [AjaxOnly]
        public IActionResult DynamicDiv()
        {
            return View();
        }

        //[ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any, NoStore = false, VaryByQueryKeys = "id", VaryByHeader = "User-Agent")]
        [ResponseCache(CacheProfileName = "Default30")]
        public IActionResult StaticPage()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}