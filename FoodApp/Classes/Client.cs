using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp
{
    [Serializable]
    class Client
    {
        readonly string login;
        private string password;
        public string name;
        public int phoneNumber;
        public Status status;

        public Client()
        {

        }

        public Client(string login, string password, string name, int phoneNumber)
        {
            this.login = login;
            this.password = password;
            this.name = name;
            status = Status.Bronze;
            this.phoneNumber = phoneNumber;
        }

        public string Login
        {
            get { return login; }
        }

        public bool CheckPassword(string password)
        {
            if(this.password == password)
            {
                return true;
            }

            return false;
        }
    }
}
