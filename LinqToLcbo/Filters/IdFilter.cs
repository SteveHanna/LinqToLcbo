using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqToLcbo
{
    public class IdFilter
    {
        public int Id { get; set; }

        public IdFilter(int id)
        {
            Id = id;
        }

        public static IdFilter operator ==(IdFilter f, int s)
        {
            return new IdFilter(s);
        }

        public static IdFilter operator !=(IdFilter f, int s)
        {
            throw new NotImplementedException();
        }
    }
}
