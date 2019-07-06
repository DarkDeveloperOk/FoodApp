using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp
{
    class ShoppingCart
    {
        Dictionary<Product, int> products = new Dictionary<Product, int>();
        double sum = 0;

        public void Add(Product product, int quantity)
        {
            products.Add(product, quantity);
            sum += (product.Price * quantity);
        }

        public void Subtract(Product product, int quantity)
        {
            if(quantity >= products[product])
            {
                products.Remove(product);
                sum -= product.Price * products[product];
            }
            else
            {
                products[product] -= quantity;
                sum -= (product.Price * quantity);
            }
        }

        public void ShowCart()
        {
            
        }
    }
}
