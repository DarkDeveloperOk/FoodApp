using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp
{
    // добавлено для себя для заполнения ProductCollection и Storage. И тестирования
    static class AdminTools
    {
        public static void AddProd()
        {
            ProductsCollection productsCollection = new ProductsCollection();
            Storage storage = new Storage();

            while (true)
            {
                Console.Write("name ");
                string name = Console.ReadLine();
                if (name == "quit")
                    break;

                Console.Write("Section ");
                string sectionStr = Console.ReadLine();
                MenuSections sections = MenuSections.Гарниры;

                if (sectionStr == "1")
                    sections = MenuSections.Первое;
                else if (sectionStr == "2")
                    sections = MenuSections.Гарниры;
                else if (sectionStr == "3")
                    sections = MenuSections.Салаты;
                else if (sectionStr == "4")
                    sections = MenuSections.Десерты;
                else if (sectionStr == "5")
                    sections = MenuSections.Напитки;

                Console.Write("price ");
                double price = double.Parse(Console.ReadLine());

                productsCollection.Add(new Product(name, sections, price));
                Console.WriteLine(new String('-', 30));
            }

            foreach (Product product in productsCollection)
            {
                Console.Write(product.Name + " Quantity ");
                int quantity = int.Parse(Console.ReadLine());

                storage.Add(product.ProductId, quantity);
            }

            DataBaseController.AllProductsSave(productsCollection);
            DataBaseController.StorageBaseSave(storage);

            Console.ReadKey();
        }

        public static void ShowStorage(Storage storage)
        {
            foreach (KeyValuePair<int, int> pair in storage)
            {
                Console.WriteLine("Product {0} Quantity {1}", pair.Key, pair.Value);
            }
        }

        public static void ReloadStorage(ref Storage storage)
        {
            Storage newStorage = new Storage();
           
            foreach(KeyValuePair<int, int> pair in storage)
            {
                Console.Write(pair.Key + " " + pair.Value);
                Console.Write(" Сколько должно быть: ");
                int quantity = int.Parse(Console.ReadLine());
                newStorage.Add(pair.Key, quantity);
            }

            storage = newStorage;
        }
    }
}
