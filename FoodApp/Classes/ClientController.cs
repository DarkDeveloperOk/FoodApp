using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FoodApp
{
    class ClientController
    {
        string login;
        string password;
        string name;
        int phoneNumber;
        string choose;

        public Client DoAuthorization(ClientsCollection clientsCollection)
        {
            Console.Write("Логин: ");
            while (true)
            {
                login = Console.ReadLine();

                if (login.ToLower() == "quit")
                {
                    Environment.Exit(0);
                    break;
                }

                if (!LoginCheck(login, clientsCollection))
                {
                    Console.WriteLine("Логин не верный или не существует! Повторите попытку");
                    continue;
                }
                else
                {
                    break;
                }

            }

            Console.Write("Пароль: ");

            while (true)
            {
                password = Console.ReadLine();

                if (password.ToLower() == "quit")
                {
                    Environment.Exit(0);
                    break;
                }

                if (!PassCheck(login, password, clientsCollection))
                {
                    Console.WriteLine("Не верный пароль! Повторите попытку");
                    continue;
                }
                break;
            }

            foreach(Client client in clientsCollection.clients)
            {
                if(client.Login == login)
                {
                    return client;
                }
            }

            return null;
        }

        public void ToRegister(ref ClientsCollection clientsCollection)
        {
            Regex ruls = new Regex(@"^[a-zA-Z0-9]+$");
            Regex phoneRegex = new Regex(@"^((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$");
            Regex nameRegex = new Regex(@"^[а-яА-Яa-zA-Z]+$");

            Console.WriteLine("ВАЖНО! Вводите только латинские символы и цифры!!!");
            Console.WriteLine(new string('-', 50));

            Console.Write("Введите логин: ");

            while (true)
            {
                login = Console.ReadLine();

                if (login == "quit")
                {
                    Environment.Exit(0);
                    break;
                }

                if (!ruls.IsMatch(login))
                {
                    Console.WriteLine("Недопустимые символы, повторите попытку!");
                    continue;
                }

                if (clientsCollection.CheckContainsLogin(login))
                {
                    Console.WriteLine("Логин уже занят! Введите другой");
                    continue;
                }
                break;
            }

            Console.Write("Введите пароль: ");

            while (true)
            {
                password = Console.ReadLine();

                if (!ruls.IsMatch(password))
                {
                    Console.WriteLine("Недопустимые символы, повторите попытку!");
                    continue;
                }

                break;
            }

            Console.Write("Введите имя: ");

            while(true)
            {
                name = Console.ReadLine();

                if (!nameRegex.IsMatch(name))
                {
                    Console.WriteLine("Недопустимые символы, повторите попытку!");
                    continue;
                }

                break;
            }

            Console.Write("Введите номер телефона: ");

            while(true)
            {
                string number = Console.ReadLine();

                if(!phoneRegex.IsMatch(number))
                {
                    Console.WriteLine("Номер указан не верно, повторите попытку!");
                    continue;
                }

                int.TryParse(string.Join("", number.Where(c => char.IsDigit(c))), out phoneNumber);
                break;
            }

            clientsCollection.AddClient(login, password, name, Status.Bronze);
            DataBaseController.ClientBaseSave(clientsCollection);

            Console.WriteLine(new string('-', 20) + "Регистрация завершена успешно" + new string('-', 20));

            Console.Write("Нажмите любую клавишу для продолжения");
            Console.ReadKey();
        }

        public void DoFirstChoice(ClientsCollection clientsCollection)
        {
            Console.WriteLine("1. Авторизация" + new string(' ', 5) + "2. Регистрация");

            while (true)
            {
                choose = Console.ReadLine();

                switch (choose.ToLower())
                {
                    case "1":
                        {
                            break;
                        }
                    case "2":
                        {
                            ToRegister(ref clientsCollection);
                            continue; ;
                        }
                    case "quit":
                        {
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Не верный выбор повторите попытку");
                            continue;
                        }
                }

                break;
            }
        }

        bool LoginCheck(string login, ClientsCollection collection)
        {
            if(collection.CheckContainsLogin(login))
            {
                return true;
            }

            return false;
        }

        bool PassCheck(string login, string password, ClientsCollection collection)
        {
            foreach (Client client in collection.clients)
            {
                if (client.Login == login)
                {
                    if (client.CheckPassword(password))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
