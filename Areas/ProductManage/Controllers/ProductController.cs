using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [Area("ProductManage")]
    public class ProductController : Controller
    {

        private readonly ProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ProductService productService,ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }



        // GET: ProductController
        [Route("cac-san-pham.cshtml")]
        public ActionResult Index()
        {
            // /Areas/AreaName/Views/ControllerName/Action.cshtml
            var products = _productService.OrderBy(p => p.Name).ToList();
            return View(products);  // /Areas/ProductManag/Views/Product/Index.cshtml
        }

    }
}
