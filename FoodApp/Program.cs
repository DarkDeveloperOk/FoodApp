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
        static ClientsCollection clientData = DataBaseController.ClientBaseLoad();
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
            ClientController clientController = new ClientController();

            clientController.DoFirstChoice(clientData);

            currentClient = clientController.DoAuthorization(clientData);

            while (true)
            {
                myCart = menu.MakeOrder();

                if (myCart == null)
                {
                    break;
                }

                int proccesCode = myCart.DoChoice();

                if (proccesCode == 1)
                {
                    continue;
                }
                else if (proccesCode == -1)
                {
                    DataBaseController.SendOrder(new Order(currentClient.name, currentClient.phoneNumber, myCart));
                    myCart = new ShoppingCart();
                    Console.WriteLine("Ваш заказ успешно отправлен. \n1. Сделать еще заказ \n2. Выход");
                    string choice;
                    while (true)
                    {
                        choice = Console.ReadLine();
                        if (choice == "1" || choice == "2")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Нет такой команды, повторите ввод");
                            continue;
                        }
                    }

                    if(choice == "1")
                    {
                        continue;
                    }

                    break;
                }
            }

            Console.WriteLine("Спасибо за использование нашего приложения :)");

            Console.ReadKey();
        }
    }
}
