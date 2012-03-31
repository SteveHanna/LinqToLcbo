using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqToLcbo
{
    public class WhereFilter
    {
        public Dictionary<string,string> NameAndValues { get; set; }

        public WhereFilter(string name, string value)
        {
            NameAndValues = new Dictionary<string, string>();
            NameAndValues.Add(name, value);
        }

        public static WhereFilter operator &(WhereFilter f, WhereFilter s)
        {

            f.NameAndValues = f.NameAndValues.Concat(s.NameAndValues).ToDictionary(o => o.Key, o => o.Value);
            return f;
        }

        public static bool operator true(WhereFilter x)
        {
            return true;
        }

        public static bool operator false(WhereFilter x)
        {
            return false;
        }
    }
}
