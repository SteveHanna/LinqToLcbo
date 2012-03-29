using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LinqToLcbo
{
    internal static class DataServiceAdapter<T>
    {
        public static  T[] Get(string query)
        {
            string productsAsJson = GetJsonDataFromApi("http://lcboapi.com/" + query.TrimEnd('?').TrimEnd('&'));
            JObject jo = JObject.Parse(productsAsJson);

            return jo["result"].Children().Select(o => o.ToObject<T>()).ToArray();
        }

        public static T GetSingle(string query)
        {
            string json = GetJsonDataFromApi("http://lcboapi.com/" + query);

            JObject jo = JObject.Parse(json);
            return jo["result"].ToObject<T>();
        }

        private static string GetJsonDataFromApi(string url)
        {
            HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
            HttpWebResponse webResponse = webRequest.GetResponse() as HttpWebResponse;
            using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
            {
                return reader.ReadToEnd();
            }
        }
    }
}