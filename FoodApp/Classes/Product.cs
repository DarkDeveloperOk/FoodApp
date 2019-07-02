using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp
{
    public class Product
    {
        public string Name { get; set; }
        public string Section { get; set; }
        public double Price { get; set; }
        public int Weight { get; set; }

        public Product(string name, string section, double price, int weight)
        {
            Name = name;
            Section = section;
            Price = price;
            Weight = weight;
        }

        public int CheckOnStorage(Storage storage)
        {
            return storage.ShowQuantity(this);
        }
    }
}
