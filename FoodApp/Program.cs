using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// не реальзована история заказов клиентов и скидка которая зависит от статуса клиента(статус должен зависить от того сколько клиент раньше заказывал
//ProductCollection - обратить внимание
//Menu - обратить внимание
namespace FoodApp
{
    class Program
    {
        static Client currentClient;
        static ClientsCollection collection = DataBaseController.ClientBaseLoad();
        static ShoppingCart myCart = new ShoppingCart();
        static Menu menu = new Menu(DataBaseController.AllProductsLoad(), DataBaseController.StorageBaseLoad());

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
