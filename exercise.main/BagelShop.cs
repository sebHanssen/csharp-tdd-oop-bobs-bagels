using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class BagelShop
    {
        public Basket basket = new Basket();
        public Menu menu = new Menu();

        public double checkPrice(Product product)
        {
            return product.Price;
        }
    }
}
