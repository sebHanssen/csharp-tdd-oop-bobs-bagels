using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        public List<Product> content = new List<Product>();
        public int basketLimit = 3;
        public string errorMessage = "Unknown Error";
        public void add(Product product)
        {
            if (content.Count() < basketLimit)
            {
                content.Add(product);
            }
            else
            {
                errorMessage = "Basket already full";
            }
        }
    }
}
