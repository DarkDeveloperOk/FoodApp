using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp
{
    static class DataBaseController
    {
        #region ClientBase
        public static void ClientBaseSave(ClientsCollection clientsCollection)
        {
            FileStream stream = new FileStream("clientsDataBase.dat", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, clientsCollection);
            stream.Close();
        }

        public static ClientsCollection ClientBaseLoad()
        {
            ClientsCollection clientsCollection;

            if (File.Exists("userBase.dat"))
            {
                FileStream clientsFileStream = new FileStream("userBase.dat", FileMode.Open, FileAccess.ReadWrite);
                BinaryFormatter formatter = new BinaryFormatter();
                clientsCollection = formatter.Deserialize(clientsFileStream) as ClientsCollection;
                clientsFileStream.Close();
            }
            else
            {
                clientsCollection = new ClientsCollection();

                FileStream stream = new FileStream("userBase.dat", FileMode.OpenOrCreate, FileAccess.Write);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, clientsCollection);
                stream.Close();
            }

            return clientsCollection;
        }
        #endregion

        #region StorageBase
        public static Storage StorageBaseLoad()
        {
            Storage storage;

            if (File.Exists("storage.dat"))
            {
                FileStream storageFileStream = new FileStream("storage.dat", FileMode.Open, FileAccess.ReadWrite);
                BinaryFormatter formatter = new BinaryFormatter();
                storage = formatter.Deserialize(storageFileStream) as Storage;
                storageFileStream.Close();
            }
            else
            {
                storage = new Storage();

                FileStream storageFileStream = new FileStream("storage.dat", FileMode.OpenOrCreate, FileAccess.Write);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(storageFileStream, storage);
                storageFileStream.Close();
            }

            return storage;
        }

        public static void StorageBaseSave(Storage storage)
        {
            FileStream storageFileStream = new FileStream("storage.dat", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(storageFileStream, storage);
            storageFileStream.Close();
        }
        #endregion

        public static void SendOrder(Order order)
        {
            FileStream OrderStream = new FileStream(order.orderId + ".dat", FileMode.Create, FileAccess.Write);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(OrderStream, order);
            OrderStream.Close();
        }

        #region AllProducts
        public static ProductsCollection AllProductsLoad()
        {
            ProductsCollection allProducts;

            if (File.Exists("allProducts.dat"))
            {
                FileStream allProductsFileStream = new FileStream("allProducts.dat", FileMode.Open, FileAccess.ReadWrite);
                BinaryFormatter formatter = new BinaryFormatter();
                allProducts = formatter.Deserialize(allProductsFileStream) as ProductsCollection;
                allProductsFileStream.Close();
            }
            else
            {
                allProducts = new ProductsCollection();

                FileStream allProductsFileStream = new FileStream("allProducts.dat", FileMode.OpenOrCreate, FileAccess.Write);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(allProductsFileStream, allProducts);
                allProductsFileStream.Close();
            }

            return allProducts;
        }

        //Для клиента этот метод не нужен, добавил его чтобы заполнить и сохранить колекцию
        public static void AllProductsSave(ProductsCollection allProducts)
        {
            FileStream allProductsFileStream = new FileStream("allProducts.dat", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(allProductsFileStream, allProducts);
            allProductsFileStream.Close();
        }
        #endregion
    }
}
