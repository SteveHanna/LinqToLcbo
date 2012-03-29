using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqToLcbo
{
    public class StoreSingle
    {
        public StoreSingle()
        {
            Id = new IntProperty("");
        }

        public IntProperty Id { get; set; }
    }
}
