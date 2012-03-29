using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqToLcbo
{
    public class ProductSingle
    {
        public ProductSingle()
        {
            Id = new IntProperty("");
        }

        public IntProperty Id { get; set; }
    }
}
