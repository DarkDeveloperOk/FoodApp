using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp
{
    class Menu
    {
        ProductsCollection allProducts;
        Storage storage;

        public Menu(ProductsCollection allProducts, Storage storage)
        {
            this.allProducts = allProducts;
            this.storage = storage;
        }

        public void SendOrder(ShoppingCart cart, ref Client client)
        {
            Dictionary<int, int> productList = new Dictionary<int, int>();

            foreach(KeyValuePair<Product, int> pair in cart)
            {
                storage.Subtract(pair.Key.ProductId, pair.Value);
                productList.Add(pair.Key.ProductId, pair.Value);
            }

            Order order = new Order(client.name, client.phoneNumber, cart.GetSum(), productList);

            client.AddOrderToHistory(order);

            DataBaseController.StorageBaseSave(storage);
            DataBaseController.SendOrder(order);
        }

        public bool CheckAailability(Product product)
        {
            if (storage.ShowQuantity(product.ProductId) > 0)
            {
                return true;
            }
            return false;
        }

        public void ShowMenu()
        {
            Console.WriteLine("cart - открыть корзину; quit - выход;" + Environment.NewLine);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(new string('-', 15) + " M e n u " + new string('-', 15));
            Console.ForegroundColor = ConsoleColor.Gray;

            int numerator = 0;

            foreach (var section in MenuSections.GetValues(typeof(MenuSections)))
            {
                ++numerator;
                Console.WriteLine(numerator + ". " + section.ToString());
            }
            Console.WriteLine(new string('-', 50));
        }

        public ShoppingCart MakeOrder(ref ShoppingCart shoppCart)
        {
            ShoppingCart shoppingCart = shoppCart;
            while (true)
            {
                bool continueStatus = true;
                ShowMenu();

                Console.Write("Введите номер раздела: ");
                List<Product> productsInSection = null;
                string choice = Console.ReadLine();
                #region ChoiceHandle
                if (choice.ToLower() == "quit")
                {
                    Environment.Exit(0);
                }
                else if (choice.ToLower() == "cart")
                {
                    continueStatus = false;
                    break;
                }
                else if (choice == "1")
                {
                    productsInSection = GetProdInSection(MenuSections.Первое);
                }
                else if (choice == "2")
                {
                    productsInSection = GetProdInSection(MenuSections.Гарниры);
                }
                else if (choice == "3")
                {
                    productsInSection = GetProdInSection(MenuSections.Салаты);
                }
                else if (choice == "4")
                {
                    productsInSection = GetProdInSection(MenuSections.Десерты);
                }
                else if (choice == "5")
                {
                    productsInSection = GetProdInSection(MenuSections.Напитки);
                }
                else
                {
                    Console.Write("Не допустимый ввод, повторите порытку: ");
                    continue;
                }
                #endregion
                Console.WriteLine(new string('-', 50));

                string s1 = "Название", s2 = "цена";
                Console.WriteLine("{0, -25} {1, -10}", s1, s2);

                for (int i = 0; i < productsInSection.Count; ++i)
                {
                    if (!CheckAailability(productsInSection.ElementAt(i)))
                    {
                        continue;
                    }

                    string name = productsInSection.ElementAt(i).Name.PadRight(productsInSection.ElementAt(i).Name.Length + (25 - productsInSection.ElementAt(i).Name.Length));
                    Console.WriteLine((i + 1) + ". " + name + productsInSection.ElementAt(i).Price);
                }

                Console.Write("Введите номер выбраного товара: ");
                Product product = null;

                while (true)
                {
                    string prodNum = Console.ReadLine();
                    if (choice.ToLower() == "quit")
                    {
                        Environment.Exit(0);
                    }
                    else if (choice.ToLower() == "cart")
                    {
                        continueStatus = false;
                        break;
                    }

                    int element = 0;
                    bool parseResult = int.TryParse(prodNum, out element);
                    if (parseResult && element > 0 && element <= productsInSection.Count)
                    {
                        product = productsInSection[element - 1];
                        break;
                    }
                    else
                    {
                        Console.Write("Не допустимый ввод, повторите порытку: ");
                    }
                }

                if (product != null)
                {
                    Console.Write("Введите количество: ");

                    while (true)
                    {
                        string quantityStr = Console.ReadLine();
                        int quantity = 0;
                        bool parseResult = int.TryParse(quantityStr, out quantity);

                        if (parseResult && quantity >= 0)
                        {
                            if (quantity == 0)
                            {
                                break;
                            }
                            else if (storage.ShowQuantity(product.ProductId) - quantity < 0)
                            {
                                Console.WriteLine("В наличии только {0}, введите другое количество(0 отмена позиции)", storage.ShowQuantity(product.ProductId));
                                continue;
                            }

                            if(shoppingCart == null)
                            {
                                shoppingCart = new ShoppingCart();
                                shoppingCart.Add(product, quantity);
                                break;
                            }

                            shoppingCart.Add(product, quantity);
                            break;
                        }
                        else
                        {
                            Console.Write("Не допустимый ввод, повторите порытку: ");
                        }
                    }
                }

                Console.Clear();

                if(continueStatus == false)
                {
                    break;
                }
            }

            return shoppingCart;
        }

        private List<Product> GetProdInSection(MenuSections section)
        {
            List<Product> prodList = new List<Product>();
            foreach (Product product in allProducts)
            {
                if (product.Section == section)
                {
                    prodList.Add(product);
                }
            }

            return prodList;
        }
    }
}
