using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Collections;

namespace LinqToLcbo
{
    public class LcboDataProvider<T, Twhere, TSingle, TOrderBy>
        where Twhere : new()
        where TSingle : new()
        where TOrderBy : new()
    {
        private string _query;

        public LcboDataProvider(string primaryResourceName, string secondaryResourceName, int secondaryResourceId)
        {
            _query = secondaryResourceName + "/" + secondaryResourceId + "/" + primaryResourceName + "?";
        }

        public LcboDataProvider(string primaryResourceName)
        {
            _query = primaryResourceName + "?";
        }

        public LcboDataProvider<T, Twhere, TSingle, TOrderBy> Where(Func<Twhere, WhereFilter> filter)
        {
            WhereFilter x = filter(new Twhere());
            Dictionary<string, string> nameValues = x.NameAndValues;

            if (nameValues.ContainsKey("id"))
            {
                if (nameValues.Count > 1)
                    throw new ArgumentException("When searching by id, there can't be other search terms");

                _query = _query.TrimEnd('?') + "/" + nameValues["id"];
                return this;
            }
            else
            {
                if (nameValues.ContainsKey("storeId"))
                    _query = "stores" + "/" + nameValues["storeId"] + "/" + _query;
                else if (nameValues.ContainsKey("productId"))
                    _query = "products" + "/" + nameValues["productId"] + "/" + _query;

                if (nameValues.ContainsKey("searchQuery"))
                    _query += "q=" + nameValues["searchQuery"] + "&";

                if (nameValues.ContainsKey("geo"))
                    _query += "geo=" + nameValues["geo"] + "&";

                var trues = nameValues.Where(o => o.Value == true.ToString()).Select(o => o.Key);
                if (trues.Count() > 0)
                    _query += "where=" + string.Join(",", trues) + "&";

                var falses = nameValues.Where(o => o.Value == false.ToString()).Select(o => o.Key);
                if (falses.Count() > 0)
                    _query += "where_not=" + string.Join(",", falses) + "&";

                return this;
            }
        }

        public LcboDataProvider<T, Twhere, TSingle, TOrderBy> OrderBy(Func<TOrderBy, OrderByFilter> filter)
        {
            _query += "order=" + filter(new TOrderBy()).Name + ".asc&";
            return this;
        }

        public LcboDataProvider<T, Twhere, TSingle, TOrderBy> ThenBy(Func<TOrderBy, OrderByFilter> filter)
        {
            _query = _query.TrimEnd('&');
            _query += "," + filter(new TOrderBy()).Name + ".asc&";
            return this;
        }

        public LcboDataProvider<T, Twhere, TSingle, TOrderBy> OrderByDescending(Func<TOrderBy, OrderByFilter> filter)
        {
            _query += "order=" + filter(new TOrderBy()).Name + ".desc&";
            return this;
        }

        public LcboDataProvider<T, Twhere, TSingle, TOrderBy> ThenByDescending(Func<TOrderBy, OrderByFilter> filter)
        {
            _query = _query.TrimEnd('&');
            _query += "," + filter(new TOrderBy()).Name + ".desc&";
            return this;
        }

        public LcboDataProvider<T, Twhere, TSingle, TOrderBy> Take(int count)
        {
            _query += "per_page=" + count + "&";
            return this;
        }

        public LcboDataProvider<T, Twhere, TSingle, TOrderBy> Skip(int count)
        {
            _query += "page=" + count + "&";
            return this;
        }

        public LcboDataProvider<T, Twhere, TSingle, TOrderBy> Select()
        {
            return this;
        }

        public List<T> ToList()
        {
            return DataServiceAdapter<T>.Get(_query).ToList();
        }

        public T[] ToArray()
        {
            return DataServiceAdapter<T>.Get(_query);
        }

        public T Single(Func<TSingle, WhereFilter> filter)
        {
            int id = int.Parse(filter(new TSingle()).NameAndValues.Single().Value);
            return DataServiceAdapter<T>.GetSingle(_query.TrimEnd('?') + "/" + id);
        }

        public T SingleOrDefault(Func<TSingle, WhereFilter> filter)
        {
            try
            {
                return Single(filter);
            }
            catch (System.Net.WebException)
            {
                return default(T);
            }
        }

        public T Single()
        {
            return DataServiceAdapter<T>.GetSingle(_query);
        }

        public T SingleOrDefault()
        {
            try
            {
                return DataServiceAdapter<T>.GetSingle(_query);
            }
            catch (System.Net.WebException)
            {
                return default(T);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var products = DataServiceAdapter<T>.Get(_query);

            foreach (var item in products)
            {
                yield return item;
            }
        }
    }
}
