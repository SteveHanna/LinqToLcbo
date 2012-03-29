using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace LinqToLcbo
{
    internal interface IDataMapper<T>
    {
        T MapFromJson(JToken jsonObj);
    }
}
