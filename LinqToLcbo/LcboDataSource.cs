using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqToLcbo
{
    public class LcboDataSource
    {
        public LcboProductProvider Products { get { return new LcboProductProvider(); } }
        public LcboStoreProvider Stores { get { return new LcboStoreProvider(); } }
        public LcboInventoryProvider Inventories { get { return new LcboInventoryProvider(); } }
    }

    public class LcboProductProvider : LcboDataProvider<Product, ProductWhere, ProductSingle, ProductOrderBy>
    {
        public LcboProductProvider() : base("products") { }
        public LcboProductProvider(string secondaryResourceName, int secondaryResourceId) : base("products", secondaryResourceName, secondaryResourceId) { }
    }

    public class LcboStoreProvider : LcboDataProvider<Store, StoreWhere, StoreSingle, StoreOrderBy>
    {
        public LcboStoreProvider() : base("stores") { }
        public LcboStoreProvider(string secondaryResourceName, int secondaryResourceId) : base("stores", secondaryResourceName, secondaryResourceId) { }
    }

    public class LcboInventoryProvider : LcboDataProvider<Inventory, InventoryWhere, InventorySingle, InventoryOrderBy>
    {
        public LcboInventoryProvider() : base("inventories") { }
        public LcboInventoryProvider(string secondaryResourceName, int secondaryResourceId) : base("inventories", secondaryResourceName, secondaryResourceId) { }

        //Inventory requires a custom implementation for Single since the API is completely different than Products & Stores
        public new Inventory Single(Func<InventorySingle, WhereFilter> filter)
        {
            var where = filter(new InventorySingle());

            if (!where.NameAndValues.ContainsKey("storeId") || !where.NameAndValues.ContainsKey("productId"))
                throw new ArgumentException("Both Store Id and Product Id are required to get a single inventory");

            return  DataServiceAdapter<Inventory>.GetSingle("stores/" + where.NameAndValues["storeId"] + "/products/" + where.NameAndValues["productId"] + "/inventory");
        }
    }
}