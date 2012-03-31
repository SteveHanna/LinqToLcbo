using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinqToLcbo;

namespace LinqToLcboTests
{
    [TestClass]
    public class InventoryTest
    {
        private string GetQuery(LcboDataProvider<Inventory, InventoryWhere, InventorySingle, InventoryOrderBy> data)
        {
            return ((string)data.GetType().BaseType.GetField("_query", System.Reflection.BindingFlags.FlattenHierarchy | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(data)).TrimEnd('&').TrimEnd('?');
        }

        [TestMethod]
        public void Test_where_and_orderby()
        {
            var data = new LcboDataSource();
            var q = data.Inventories.Where(o => o.IsDead == true).OrderBy(o => o.Quantity);

            Assert.AreEqual("inventories?where=is_dead&order=quantity.asc", GetQuery(q));
        }

        [TestMethod]
        public void Test_product_inventories()
        {
            var data = new LcboDataSource();
            var q = data.Inventories.Where(o => o.ProductId == 18);

            Assert.AreEqual("products/18/inventories", GetQuery(q));
        }

        [TestMethod]
        public void Test_inventories_in_product()
        {
            var data = new LcboDataSource();
            Product product = data.Products.Single(o => o.Id == 18);
            var q = product.Inventories;

            Assert.AreEqual("products/18/inventories", GetQuery(q));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_single_throws()
        {
            var data = new LcboDataSource();
            data.Inventories.Single(o => o.StoreId == 1);
        }

        [TestMethod]
        public void Test_single()
        {
            var data = new LcboDataSource();
            Inventory inventory = data.Inventories.Single(o => o.StoreId == 511 && o.ProductId == 18);

            Assert.IsTrue(inventory.ProductId == 18);
            Assert.IsTrue(inventory.StoreId == 511);
        }

        [TestMethod]
        public void Test_whhere_then_single()
        {
            var data = new LcboDataSource();

            var inventory = (from i in data.Inventories
                    where i.ProductId == 18 && i.StoreId == 511
                    select i).Single();

            Assert.AreEqual("stores/511/products/18/inventory", GetQuery(q));
        }
    }
}
