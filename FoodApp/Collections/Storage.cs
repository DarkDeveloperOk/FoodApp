using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FoodApp
{
    [Serializable]
    public class Storage : IEnumerable, IEnumerator
    {
        Dictionary<Product, int> storage = new Dictionary<Product, int>();

        public int ShowQuantity(Product product)
        {
            return storage[product];
        }

        public void Remove(Product product, int quantity)
        {
            storage[product] -= quantity;
        }

        public void Add(Product product, int quantity)
        {
            storage[product] += quantity;
        }

        int position = -1;

        public object Current
        {
            get { return storage.ElementAt(position); }
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if(position < storage.Count - 1)
            {
                position++;
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

        public Storage Load()
        {
            Storage loadStorage;

            if (File.Exists("storage.dat"))
            {
                FileStream usersFileStream = new FileStream("storage.dat", FileMode.Open, FileAccess.ReadWrite);
                BinaryFormatter formatter = new BinaryFormatter();
                loadStorage = formatter.Deserialize(usersFileStream) as Storage;
                usersFileStream.Close();
            }
            else
            {
                loadStorage = new Storage();
            }

            return loadStorage;
        }

        public void Save(Storage storage)
        {
            FileStream stream = new FileStream("storage.dat", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, storage);
            stream.Close();
        }
    }
}
