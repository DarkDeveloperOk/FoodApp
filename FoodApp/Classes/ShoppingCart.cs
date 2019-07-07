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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Корзина:");
            Console.ForegroundColor = ConsoleColor.Gray;

            string s1 = "Название", s2 = "цена", s3 = "кол", s4 = "сумма";
            Console.WriteLine("{0, -25} {1, -10} {2, -5} {3}", s1, s2, s3, s4);

            foreach (KeyValuePair<Product, int> pair in products)
            {
                string name = pair.Key.Name.PadRight(pair.Key.Name.Length + (25 - pair.Key.Name.Length));

                Console.WriteLine("{0} {1, -11} {2, -4} {3}", name, pair.Key.Price, pair.Value, pair.Key.Price * pair.Value);
            }
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("Общая сумма заказа: {0, 29}", sum);
        }

    }
}
