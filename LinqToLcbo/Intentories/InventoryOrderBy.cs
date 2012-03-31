using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqToLcbo
{
    public class InventoryOrderBy
    {
        public InventoryOrderBy()
        {
            Quantity = new OrderByFilter("quantity");
            UpdatedDate = new OrderByFilter("updated_on");
        }

        public OrderByFilter Quantity { get; set; }
        public OrderByFilter UpdatedDate { get; set; }
    }
}
