using System.Collections.Generic;
using System.Linq;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Services
{
    public class CartService
    {
        private readonly  ICartDao _cartDao;
        private readonly ProductService _productService;

        public CartService(ICartDao cartDao, IProductDao productDao, IProductCategoryDao productCategoryDao, ISupplierDao supplierDao)
        {
            _cartDao = cartDao;
            _productService = new ProductService(productDao, productCategoryDao, supplierDao);

        }

        public void IncreaseProduct(int productId)
        {
            var product = _productService.GetProduct(productId);
            _cartDao.IncreaseProduct(product);
        }

        public Dictionary<Product,int> GetCart()
        {
            return _cartDao.GetAll();
        }

        public void RemoveProduct(int productId)
        {
            var product = _productService.GetProduct(productId);
            _cartDao.RemoveProduct(product);
        }

        public void DecreaseProduct(int productId)
        {
            var product = _productService.GetProduct(productId);
            _cartDao.DecreaseProduct(product);
        }

        public void RemoveAllProducts()
        {
            _cartDao.RemoveAllProducts();
        }
    }
}
