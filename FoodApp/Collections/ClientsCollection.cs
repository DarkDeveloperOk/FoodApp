using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp
{
    [Serializable]
    class ClientsCollection
    {
        public List<Client> clients = new List<Client>();

        public void AddClient(string login, string password, string name, Status status)
        {
            clients.Add(new Client(login, password, name, status));
        }

        public bool CheckContainsLogin(string login)
        {
            foreach(Client client in clients)
            {
                if(client.Login == login)
                {
                    return true;
                }
            }

            return false;
        }

        public void Save()
        {
            FileStream stream = new FileStream("clientsDataBase.dat", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, clients);
            stream.Close();
        }

        public ClientsCollection Load()
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
    }
}
