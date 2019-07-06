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

        
    }
}
