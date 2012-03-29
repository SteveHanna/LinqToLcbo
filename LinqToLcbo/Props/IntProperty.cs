using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqToLcbo
{
    public class IntProperty
    {
        internal string Name { get; set; }

        public IntProperty(string name)
        {
            Name= name;
        }

        public static WhereFilter operator ==(IntProperty f, int s)
        {
            return new WhereFilter(f.Name, s.ToString());
        }

        public static WhereFilter operator !=(IntProperty f, int s)
        {
            throw new NotImplementedException();
        }
    }
}
