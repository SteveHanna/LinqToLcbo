using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqToLcbo
{
    public class LcboResult<T>
    {
        public T[] Result { get; set; }
        public Pager Pager { get; set; }
    }
}