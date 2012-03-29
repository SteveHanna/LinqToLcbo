using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqToLcbo
{
    public class OrderByFilter
    {
        public string Name { get; private set; }

        public OrderByFilter(string name)
        {
            Name = name;
        }
    }
}
