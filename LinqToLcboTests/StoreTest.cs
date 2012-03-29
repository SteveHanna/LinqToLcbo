using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinqToLcbo;

namespace LinqToLcboTests
{
    [TestClass]
    public class StoreTest
    {
        private string GetQuery(LcboDataProvider<Store, StoreWhere, StoreSingle, StoreOrderBy> data)
        {
            return ((string)data.GetType().BaseType.GetField("_query", System.Reflection.BindingFlags.FlattenHierarchy | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(data)).TrimEnd('&').TrimEnd('?');
        }

        [TestMethod]
        public void Test_stores_searchQuery()
        {
            var data = new LcboDataSource();
            var q = data.Stores.Where(o => o.SearchQuery == "spadina");

            Assert.AreEqual("stores?q=spadina", GetQuery(q));
        }

        [TestMethod]
        public void Test_stores_geo()
        {
            var data = new LcboDataSource();
            var q = data.Stores.Where(o => o.Geolocation == "spadina");

            Assert.AreEqual("stores?geo=spadina", GetQuery(q));
        }

        [TestMethod]
        public void Test_stores_with_multi_where()
        {
            var data = new LcboDataSource();
            var q = data.Stores.Where(o => o.Geolocation == "spadina" && o.SearchQuery == "king");

            Assert.AreEqual("stores?q=king&geo=spadina", GetQuery(q));
        }

        [TestMethod]
        public void Test_stores_with_product()
        {
            var data = new LcboDataSource();
            data.Stores.Where(o => o.ProductId == 10 && o.Geolocation == "spadina");

            var q = data.Stores.Where(o => o.ProductId == 18);

            Assert.AreEqual("products/18/stores", GetQuery(q));
        }

        [TestMethod]
        public void Test_stores_signle()
        {
            var data = new LcboDataSource();
         
            Store store = data.Stores.Single(o => o.Id == 511);
            Assert.AreEqual(511, store.Id);
        }

        [TestMethod]
        public void Test_GEO()
        {
            var lcbo = new LcboDataSource();
            //var stores = lcbo.Stores.Where(o => o.Geolocation == "Spadina").OrderBy(o => o.Distance).ToList();
            //var products = stores[0].Products.Where(o => o.SearchQuery == "heineken");

            var store = (from s in lcbo.Stores
                        where s.Geolocation == "Spadina"
                        orderby s.Distance
                        select s).ToList();

            var products = from p in store[0].Products
                           where p.SearchQuery == "heineken"
                           select p;



            Store store = lcbo.Stores.Single(o => o.Id == 511);
            Assert.AreEqual(511, store.Id);
        }
    }
}
