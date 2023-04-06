using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;

namespace Codecool.CodecoolShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private ProductService ProductService { get; set; }

        private CartService CartService { get; set; }

        private ProductViewModel ProductViewModel { get; set; }

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
            ProductService = new ProductService(
                ProductDaoMemory.GetInstance(),
                ProductCategoryDaoMemory.GetInstance(),
                SupplierDaoMemory.GetInstance());
            CartService = new CartService(
                CartDao.GetInstance(),
                ProductDaoMemory.GetInstance(),
                ProductCategoryDaoMemory.GetInstance(),
                SupplierDaoMemory.GetInstance());
            ProductViewModel = new ProductViewModel();
            ProductViewModel.ProductsInCart = CartService.GetCart();
        }

        public IActionResult Index(int id = 1, string categoryOrSupplier = "category")
        {
            if (categoryOrSupplier != "category")
            {
                var productsBySupplier = ProductService.GetProductsBySupplier(id);
                ProductViewModel.Products = productsBySupplier.ToList();
                ProductViewModel.CategoryOrSupplier = categoryOrSupplier;
                return View(ProductViewModel);
            }
            var productsByCategory = ProductService.GetProductsForCategory(id);
            ProductViewModel.Products = productsByCategory.ToList();
            ProductViewModel.CategoryOrSupplier = categoryOrSupplier;
            return View(ProductViewModel);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
