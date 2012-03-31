using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqToLcbo
{
    public class InventorySingle
    {
        public InventorySingle()
        {
            ProductId = new IntProperty("productId");
            StoreId = new IntProperty("storeId");
        }

        public IntProperty ProductId { get; set; }
        public IntProperty StoreId { get; set; }
    }
}
