using System;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Models
{
    public class OrderDetails
    {
        public OrderDetails(int productId, string productName, decimal productPrice, int numberOfProduct)
        {
            ProductId = productId;
            ProductName = productName;
            ProductPrice = productPrice;
            NumberOfProduct = numberOfProduct;
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public int NumberOfProduct { get; set; }

    }
}
