using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinqToLcbo;

namespace LinqToLcboTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class ProductTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        private string GetQuery(LcboDataProvider<Product, ProductWhere, ProductSingle, ProductOrderBy> data)
        {
            return ((string)data.GetType().BaseType.GetField("_query", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(data)).TrimEnd('&').TrimEnd('?');
        }

        [TestMethod]
        public void Test_where()
        {
            var data = new LcboDataSource();
            var q = data.Products.Where(o => o.SearchQuery == "Scotch");

            Assert.AreEqual("products?q=Scotch", GetQuery(q));
        }

        [TestMethod]
        public void Test_where_not()
        {
            var data = new LcboDataSource();
            var q = data.Products.Where(o => !o.IsSeasonal);

            Assert.AreEqual("products?where_not=is_seasonal", GetQuery(q));
        }

        [TestMethod]
        public void Test_multi_clause_where()
        {
            var data = new LcboDataSource();
            var q = data.Products.Where(o => o.SearchQuery == "Scotch" && o.IsDead);

            Assert.AreEqual("products?q=Scotch&where=is_dead", GetQuery(q));
        }

        [TestMethod]
        public void Test_multi_clause_where_and_where_not()
        {
            var data = new LcboDataSource();
            var q = data.Products.Where(o => o.SearchQuery == "Scotch" && o.IsDead && o.IsKosher && !o.IsSeasonal);

            Assert.AreEqual("products?q=Scotch&where=is_dead,is_kosher&where_not=is_seasonal", GetQuery(q));
        }

        [TestMethod]
        public void Test_orderby()
        {
            var data = new LcboDataSource();
            var q = data.Products.OrderBy(o => o.Id);

            Assert.AreEqual("products?order=id.asc", GetQuery(q));
        }

        [TestMethod]
        public void Test_multi_clause_orderby()
        {
            var data = new LcboDataSource();
            var q = data.Products.OrderBy(o => o.Id).ThenBy(o => o.Price).ThenByDescending(o => o.ReleasedDate);

            Assert.AreEqual("products?order=id.asc,price_in_cents.asc,released_on.desc", GetQuery(q));
        }

        [TestMethod]
        public void Test_where_and_orderby()
        {
            var data = new LcboDataSource();
            var q = data.Products.Where(o => o.IsDead).OrderBy(o => o.Id);

            Assert.AreEqual("products?where=is_dead&order=id.asc", GetQuery(q));
        }

        [TestMethod]
        public void Test_single()
        {
            var data = new LcboDataSource();
            Product p = data.Products.Single(o => o.Id == 18);

            Assert.AreEqual(18, p.Id);
        }

        [TestMethod]
        public void Test_where_then_single()
        {
            var data = new LcboDataSource();

            Product heineken = (from p in data.Products
                                where p.Id == 18
                                select p).Single();

            Assert.AreEqual(18, heineken.Id);
        }
        [TestMethod]
        public void Test_where_then_singleOrDefault()
        {
            var data = new LcboDataSource();

            Product heineken = (from p in data.Products
                                where p.Id == 180000
                                select p).SingleOrDefault();

            Assert.IsNull(heineken);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Net.WebException))]
        public void Test_single_with_exception()
        {
            var data = new LcboDataSource();
            Product p = data.Products.Single(o => o.Id == 1800000);
        }

        [TestMethod]
        public void Test_singleOrDefault()
        {
            var data = new LcboDataSource();
            Product p = data.Products.SingleOrDefault(o => o.Id == 1800000);

            Assert.IsNull(p);
        }


        [TestMethod]
        public void Test_enumerator()
        {
            var data = new LcboDataSource();
            var products = data.Products.Where(o => !o.IsDead && o.SearchQuery == "heineken");

            foreach (var p in products)
            {
                Assert.AreEqual("Heineken", p.Name);
                break;
            }
        }

        [TestMethod]
        public void Test_where_and()
        {
            var data = new LcboDataSource();
            var q = data.Products.Where(o => o.IsDead && o.IsDiscontinued);

            Assert.AreEqual("products?where=is_dead,is_discontinued", GetQuery(q));
        }

        [TestMethod]
        public void Test_bool_where()
        {
            var data = new LcboDataSource();
            var q = data.Products.Where(o => o.IsDead);

            Assert.AreEqual("products?where=is_dead", GetQuery(q));
        }

        [TestMethod]
        public void Test_toList()
        {
            var data = new LcboDataSource();
            var products = data.Products.Where(o => !o.IsDead && !o.IsVqa && o.SearchQuery == "heineken").ToList();
            Assert.AreEqual("Heineken", products.First().Name);
        }

        [TestMethod]
        public void Test_products_in_store_by_id()
        {
            var data = new LcboDataSource();
            var q = data.Products.Where(o => o.StoreId == 511);

            Assert.AreEqual("stores/511/products", GetQuery(q));
        }

        [TestMethod]
        public void Test_products_in_store_lazy_loaded()
        {
            var data = new LcboDataSource();
            var q = data.Stores.Single(o => o.Id == 511);
            var products = q.Products;

            Assert.AreEqual("stores/511/products", GetQuery(products));
        }

        [TestMethod]
        public void Test_products_in_store_with_where()
        {
            var data = new LcboDataSource();
            var q = data.Products.Where(o => o.StoreId == 511 && o.SearchQuery == "heineken");
            var x = q.ToList();

            Assert.AreEqual("stores/511/products?q=heineken", GetQuery(q));
        }

        [TestMethod]
        public void Test_take()
        {
            var data = new LcboDataSource();
            var q = data.Products.Where(o => o.SearchQuery == "heineken").Take(10);
            Assert.AreEqual("products?q=heineken&per_page=10", GetQuery(q));
        }

        [TestMethod]
        public void Test_skip()
        {
            var data = new LcboDataSource();
            var q = data.Products.Where(o => o.SearchQuery == "heineken").Skip(10);
            Assert.AreEqual("products?q=heineken&page=10", GetQuery(q));
        }

        [TestMethod]
        public void Test_take_and_skip()
        {
            var data = new LcboDataSource();
            var q = data.Products.Where(o => o.SearchQuery == "heineken").Take(10).Skip(2);
            Assert.AreEqual("products?q=heineken&per_page=10&page=2", GetQuery(q));
        }

        [TestMethod]
        public void Test_select()
        {
            var data = new LcboDataSource();
            var x = from product in data.Products
                    where product.SearchQuery == "heineken" && !product.IsDiscontinued
                    select product;

            Assert.AreEqual("products?q=heineken&where_not=is_discontinued", GetQuery(x));
        }
    }
}
