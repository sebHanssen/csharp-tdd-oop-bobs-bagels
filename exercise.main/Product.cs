using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Product
    {
        private string _name;
        public Product(string name)
        {
            _name = name;
        }
        public string Name { get { return _name; } set { _name = value; } }
    }
}
