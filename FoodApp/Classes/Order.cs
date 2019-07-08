using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp
{
    [Serializable]
    class Order
    {
        public string orderId;
        public string clientName;
        public int phoneNumber;
        public double sum;
        public Dictionary<int, int> products;

        public Order(string clientName, int phoneNumber, double sum, Dictionary<int, int> products)
        {
            this.clientName = clientName;
            this.phoneNumber = phoneNumber;
            this.products = products;
            this.sum = sum;
            orderId = "O" + DateTime.Now.Ticks.ToString().Remove(0, 9);
        }
    }
}
