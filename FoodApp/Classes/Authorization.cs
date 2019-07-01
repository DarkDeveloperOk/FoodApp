using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FoodApp
{
    class Authorization
    {
        string login;
        string password;
        string name;
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
                Regex nameRegex = new Regex(@"^[а-яА-Яa-zA-Z0-9]+$");

                if (!nameRegex.IsMatch(name))
                {
                    Console.WriteLine("Недопустимые символы, повторите попытку!");
                    continue;
                }

                break;
            }

            Console.WriteLine(new string('-', 20) + "Регистрация завершена успешно" + new string('-', 20));

            clientsCollection.AddClient(login, password, name, Status.Bronze);

            clientsCollection.Save();

            Console.Write("Нажмите любую клавишу для продолжения");
            Console.ReadKey();
        }

        public void StartApp(ClientsCollection clientsCollection)
        {
            Console.WriteLine("1. Вход в дневник." + new string(' ', 5) + "2.Регистрация нового пользователя");

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
