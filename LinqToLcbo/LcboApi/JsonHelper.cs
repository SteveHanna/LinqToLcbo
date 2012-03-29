using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqToLcbo
{
    internal static class JsonHelper
    {
        public static DateTime? ParseToDateTime(this Newtonsoft.Json.Linq.JToken dateAsString)
        {
            if (!string.IsNullOrEmpty((string)dateAsString))
                return DateTime.Parse((string)dateAsString);
            else
                return null;
        }
    }
}
