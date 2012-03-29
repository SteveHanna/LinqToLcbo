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
}