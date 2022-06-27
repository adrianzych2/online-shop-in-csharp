using System.Collections.Generic;

namespace Codecool.CodecoolShop.Models
{
    public class ProductViewModel
    { 
        public Dictionary<Product,int> ProductsInCart { get; set; }
        public List<Product> Products { get; set; }

        public string CategoryOrSupplier { get; set; }
    }
}
