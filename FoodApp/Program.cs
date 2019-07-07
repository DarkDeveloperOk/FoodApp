using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp
{
    class Program
    {
        static Client currentClient;
        static ClientsCollection collection = DataBaseController.ClientBaseLoad();
        static Storage storage = DataBaseController.StorageBaseLoad();
        static ShoppingCart myCart = new ShoppingCart();

        static void Clear()
        {
            Console.Clear();
            Console.WriteLine("INFO: quit - выход; data - показать записи;");
            Console.WriteLine(new string('-', 80));
        }

        static void Main(string[] args)
        {

        }
    }
}
