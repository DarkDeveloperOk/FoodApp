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
        public static void ClientBaseSave(List<Client> clients)
        {
            FileStream stream = new FileStream("clientsDataBase.dat", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, clients);
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
    }
}
