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
        [Serializable]
        static Dictionary<int, int> storage;

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
