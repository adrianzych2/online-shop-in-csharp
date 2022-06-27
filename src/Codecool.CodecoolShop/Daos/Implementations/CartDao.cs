using System.Collections.Generic;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Daos.Implementations
{
    public class CartDao : ICartDao
    {
        private Cart _data = new Cart();
        private static CartDao _instance = null;
        

        public static CartDao GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CartDao();
            }

            return _instance;
        }


        public Dictionary<Product,int> GetAll()
        {
            return _data.ListOfProducts;
        }

        public void IncreaseProduct(Product product)
        {
            if (_data.ListOfProducts.ContainsKey(product))
            {
                _data.ListOfProducts[product] += 1;
            }
            else
            {
                _data.ListOfProducts.Add(product, 1);
            }
        }

        public void DecreaseProduct(Product product)
        {
            if (_data.ListOfProducts[product] > 1)
            {
                _data.ListOfProducts[product] -= 1;
            }
            else
            {
                _data.ListOfProducts.Remove(product);
            }

        }

        public void RemoveProduct(Product product)
        {
            _data.ListOfProducts.Remove(product);
        }

        public void RemoveAllProducts()
        {
            _data.ListOfProducts.Clear();
        }
    }
}
