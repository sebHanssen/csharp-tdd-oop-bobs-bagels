using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Menu
    {
        public List<Product> bagels = new List<Product>();
        public Menu()
        {
            bagels.Add(new Product("Plain Bagel"));
            bagels.Add(new Product("Onion Bagel"));
        }
    }
}
