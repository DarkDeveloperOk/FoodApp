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
        public MenuSections Section { get; set; }
        public double Price { get; set; }
        readonly int productId;

        public Product(string name, MenuSections section, double price, int weight)
        {
            Name = name;
            Section = section;
            Price = price;
            productId = Int32.Parse(DateTime.Now.Ticks.ToString().Remove(0, 9));
        }

        public int ProductId
        {
            get { return productId; }
        }
    }
}
