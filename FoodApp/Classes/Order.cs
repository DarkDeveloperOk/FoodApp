using System;
using System.Collections.Generic;
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
        public ShoppingCart shoppingCart;

        public Order(string clientName, int phoneNumber, ShoppingCart shoppingCart)
        {
            this.clientName = clientName;
            this.phoneNumber = phoneNumber;
            this.shoppingCart = shoppingCart;
            orderId = "O" + DateTime.Now.Ticks.ToString().Remove(0, 9);
        }
    }
}
