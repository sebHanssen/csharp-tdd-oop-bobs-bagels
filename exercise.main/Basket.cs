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
        public Menu menu = new Menu();
        public int basketLimit = 3;
        public string errorMessage = "Unknown Error";
        public string userQuery = "";
        public void add(Product product)
        {
            if (content.Count() < basketLimit)
            {
                if (!menu.menuList.Contains((product.Sku, product.Price, product.Name, product.Variant))){
                    errorMessage = "This product does not exist in our menu.";
                } else
                {
                    content.Add(product);
                }
                
            }
            else
            {
                errorMessage = "Basket already full";
            }
        }

        public void add(string sku, int amount)
        {
            if (!menu.products.Any(x => sku == x.Sku))
            {
                errorMessage = "This product does not exist in our menu.";
            }
            else
            {
                var item = menu.products.Where(x => sku == x.Sku).FirstOrDefault();
                for (int i = 0; i < amount; i++)
                {
                    if (content.Count() < basketLimit)
                    {
                        content.Add(item);
                    }
                    else
                    {
                        errorMessage = "Basket already full";
                        break;
                    }
                }
            }
        }


        public void addFilling(Product item, Filling filling)
        {
            if (!content.Contains(item))
            {
                errorMessage = $"There is no {item.Variant} {item.Name} in your basket to add {filling.Variant} on.";
            } else if (item.Name != "Bagel")
            {
                errorMessage = $"You can only put filling on a Bagel";
            } else
            {
                Bagel bagel = item as Bagel;
                userQuery = $"The price of this filling is {Math.Round(filling.Price, 2)}$. Are you sure you want to add it?";
                bagel.addFilling(filling);
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
            var uniqueContent = content.Distinct().ToList();
            
            content.Where(x => )
            return Math.Round(content.Sum(x => x.Price), 2);
        }

        public List<List<Product>> findDiscounts()
        {
            var uniqueContent = content.Distinct().ToList();
            content.Where(x => )
            return;
        }
    }
}
