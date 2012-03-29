using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqToLcbo
{
    public class StoreOrderBy
    {
        public StoreOrderBy()
        {
            Id = new OrderByFilter("id");
            Distance = new OrderByFilter("distance_in_meters");
            InventoryVolume = new OrderByFilter("inventory_volume_in_milliliters");
            InventoryCount = new OrderByFilter("inventory_count");
            ProductsCount = new OrderByFilter("products_count");
            InventoryPrice = new OrderByFilter("inventory_price_in_cents");
        }

        public OrderByFilter Id { get; set; }
        public OrderByFilter Distance { get; set; }
        public OrderByFilter InventoryVolume { get; set; }
        public OrderByFilter ProductsCount { get; set; }
        public OrderByFilter InventoryCount { get; set; }
        public OrderByFilter InventoryPrice { get; set; }
    }
}

