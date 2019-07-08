using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp
{
    [Serializable]
    class ShoppingCart : IEnumerator, IEnumerable
    {
        Dictionary<Product, int> products = new Dictionary<Product, int>();

        public void Add(Product product, int quantity)
        {
            if (products.ContainsKey(product))
            {
                products[product] += quantity;
            }
            else
            {
                products.Add(product, quantity);
            }
        }

        public void Subtract(Product product, int quantity)
        {
            if (quantity >= products[product])
            {
                products.Remove(product);
            }
            else
            {
                products[product] -= quantity;
            }
        }

        public double GetSum()
        {
            double sum = 0;

            foreach (KeyValuePair<Product, int> pair in products)
            {
                sum += (pair.Key.Price * pair.Value);
            }

            return sum;
        }

        private void ShowCart()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Корзина:");
            Console.ForegroundColor = ConsoleColor.Gray;

            string s1 = "Название", s2 = "цена", s3 = "кол", s4 = "сумма";
            Console.WriteLine("{0, -23} {1, -10} {2, -5} {3}", s1, s2, s3, s4);

            int number = 0;
            foreach (KeyValuePair<Product, int> pair in products)
            {
                string name = pair.Key.Name.PadRight(pair.Key.Name.Length + (25 - pair.Key.Name.Length));

                Console.WriteLine("{0}.{1} {2, -11} {3, -4} {4}", number += 1, name, pair.Key.Price, pair.Value, pair.Key.Price * pair.Value);
            }
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("Общая сумма заказа: {0, 29}" + Environment.NewLine, GetSum());
        }

        private void EditShoppingCart()
        {
            Console.Write("Номер товара, который надо изменить: ");
            Product product;

            while (true)
            {
                int productNumber;
                string prod = Console.ReadLine();
                bool parseResult = int.TryParse(prod, out productNumber);

                if (!parseResult || productNumber < 1 || productNumber > products.Count)
                {
                    Console.Write("Не допустимый ввод, повторите порытку: ");
                    continue;
                }

                product = products.ElementAt(productNumber - 1).Key;
                break;
            }


            Console.WriteLine("1. Добавить 2. Убрать 3. Отменить редактирование");
            string choice;

            while (true)
            {
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    int quantity;

                    Console.Write("Количество: ");
                    while(true)
                    {
                        string quant = Console.ReadLine();
                        bool parseResult = int.TryParse(quant, out quantity);

                        if (!parseResult || quantity < 0)
                        {
                            Console.Write("Не допустимый ввод, повторите порытку: ");
                            continue;
                        }
                        break;
                    }

                    Add(product, quantity);
                }

                else if(choice == "2")
                {
                    int quantity;

                    Console.Write("Количество: ");
                    while (true)
                    {
                        string quant = Console.ReadLine();
                        bool parseResult = int.TryParse(quant, out quantity);

                        if (!parseResult || quantity < 0)
                        {
                            Console.Write("Не допустимый ввод, повторите порытку: ");
                            continue;
                        }
                        break;
                    }

                    Subtract(product, quantity);
                }

                else if(choice == "3")
                {
                    break;
                }
                else
                {
                    Console.Write("Не допустимый ввод, повторите порытку: ");
                    continue;
                }
                break;
            }
        }

        public int DoChoice()
        {
            int endCode;

            while (true)
            {
                Console.Clear();

                Console.WriteLine("cont - продолжить заказ; edit - редактировать; send - отправить; quit - выход;");
                Console.WriteLine(new String('-', 80));

                ShowCart();

                string choose = Console.ReadLine().ToLower();

                if (choose == "quit")
                {
                    Environment.Exit(0);
                }
                else if (choose == "cont")
                {
                    endCode = 1;
                    break;
                }
                else if (choose == "edit")
                {
                    EditShoppingCart();
                    Console.Clear();
                    continue;
                }
                else if (choose == "send")
                {
                    endCode = -1;
                    break;
                }
                else
                {
                    Console.WriteLine("Нет такой команды, повторите ввод");
                    continue;
                }
            }

            return endCode;
        }

        int position = -1;

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if(position < products.Count - 1)
            {
                ++position;
                return true;
            }
            else
            {
                Reset();
                return false;
            }
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current
        {
            get { return products.ElementAt(position); }
        }
    }
}
