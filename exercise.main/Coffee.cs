﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Coffee : Product
    {
        public Coffee(string sku, double price, string name, string variant) : base(sku, price, name, variant)
        {

        }
    }
}
