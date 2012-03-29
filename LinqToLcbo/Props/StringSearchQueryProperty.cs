using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqToLcbo
{
    public class StringSearchQueryProperty
    {
        internal string Name { get; set; }

        public StringSearchQueryProperty(string name)
        {
            Name = name;
        }

        public static WhereFilter operator ==(StringSearchQueryProperty f, string s)
        {
            return new WhereFilter(f.Name, s);
        }

        public static WhereFilter operator !=(StringSearchQueryProperty f, string s)
        {
            throw new NotImplementedException();
        }
    }
}
