using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Bagel : Product
    {
        private List<Filling> _fillings = new List<Filling>();
        public Bagel(string sku, double price, string name, string variant, List<Filling> fillings) : base(sku, price, name, variant)
        {
            _fillings = fillings;
        }
        public List<Filling> Fillings { get { return _fillings; } set { _fillings = value; } }
        public void addFilling(Filling filling)
        {
            Price = Price + filling.Price;
            Fillings.Add(filling);
        }
    }
}
