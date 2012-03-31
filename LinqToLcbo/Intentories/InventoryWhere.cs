using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqToLcbo
{
    public class InventoryWhere
    {
        public InventoryWhere()
        {
            StoreId = new IntProperty("storeId");
            ProductId = new IntProperty("productId");
            IsDead = new BoolProperty("is_dead");
        }

        public IntProperty StoreId { get; set; }
        public IntProperty ProductId { get; set; }
        public BoolProperty IsDead { get; set; }
    }
}
