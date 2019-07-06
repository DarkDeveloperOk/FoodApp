using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp
{
    [Serializable]
    class Storage : IEnumerable, IEnumerator
    {
        Dictionary<int, int> storage = new Dictionary<int, int>();

        public void Add(int id, int quantity)
        {
            if(storage.ContainsKey(id))
            {
                storage[id] += quantity;
            }
            else
            {
                storage.Add(id, quantity);
            }
        }

        public int Subtract(int id, int quantity)
        {
            if(!ContainsProd(id))
            {
                return -1;
            }

            else if(storage[id] - quantity < 0)
            {
                return 0;
            }

            storage[id] -= quantity;
            return 1;

        }

        public int ShowQuantity(int id)
        {
            if(!ContainsProd(id))
            {
                return -1;
            }

            return storage[id];
        }

        public bool ContainsProd(int id)
        {
            if(storage.ContainsKey(id))
            {
                return true;
            }

            return false;
        }

        int position = -1;

        public object Current
        {
            get { return storage[position]; }
        }

        public bool MoveNext()
        {
            if(position < storage.Count - 1)
            {
                ++position;
                return true;
            }

            Reset();
            return false;
        }

        public void Reset()
        {
            position = -1;
        }

        public IEnumerator GetEnumerator()
        {
            return storage.GetEnumerator();
        }

    }
}
