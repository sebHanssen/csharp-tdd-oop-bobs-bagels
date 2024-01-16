using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Emit;
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

        public void changeBasketLimit(int newLimit)
        {
            if (content.Count() < newLimit)
            {
                basketLimit = newLimit;
            }
            else
            {
                errorMessage = "Limit cannot be lower than current items in basket";
            }
        }

        public void remove(Product product)
        {
            if (content.Contains(product))
            {
                content.RemoveAll(x => x == product);
            }
            else
            {
                errorMessage = $"There is no {product.Variant} {product.Name} in your basket to remove";
            }
        }

        public double total()
        {
            return content.Sum(x => x.Price);
        }
    }
}
