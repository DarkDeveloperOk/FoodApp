using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp
{
    [Serializable]
    class ProductsCollection : IEnumerable, IEnumerator
    {
        List<Product> allProducts = new List<Product>();

        public void Add(Product product)
        {
            allProducts.Add(product);
        }

        public bool Contains(Product product)
        {
            return allProducts.Contains(product);
        }

        int position = -1;

        public object Current
        {
            get { return allProducts[position]; }
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if(position < allProducts.Count - 1)
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
    }
}
