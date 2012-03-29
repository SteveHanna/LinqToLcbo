using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqToLcbo
{
    public class BoolProperty
    {
        internal WhereFilter Where { get; set; }

        public BoolProperty(string name)
        {
            Where = new WhereFilter(name, true.ToString());
        }

        public static implicit operator WhereFilter(BoolProperty f)
        {
            return f.Where;
        }

        public static WhereFilter operator !(BoolProperty f)
        {
            f.Where.NameAndValues[f.Where.NameAndValues.Single().Key] = false.ToString();
            return f.Where;
        }

        public static WhereFilter operator ==(BoolProperty f, bool b)
        {
            f.Where.NameAndValues[f.Where.NameAndValues.Single().Key] = b.ToString();
            return f;
        }

        public static WhereFilter operator !=(BoolProperty f, bool b)
        {
            f.Where.NameAndValues[f.Where.NameAndValues.Single().Key] = b.ToString();
            return f;
        }

        public static BoolProperty operator &(BoolProperty f, BoolProperty s)
        {
            f.Where.NameAndValues = f.Where.NameAndValues.Concat(s.Where.NameAndValues).ToDictionary(o => o.Key, o => o.Value);
            return f;
        }

        public static bool operator true(BoolProperty x)
        {
            return true;
        }

        public static bool operator false(BoolProperty x)
        {
            return false;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
