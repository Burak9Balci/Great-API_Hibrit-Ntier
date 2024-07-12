



using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.SessionExtention
{
    public static class SessionExtention 
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            string stringObject = JsonConvert.SerializeObject(value);
            session.SetString(key, stringObject);
        }
        public static T GetObject<T>(this ISession session, string key) where T : class
        {
            string obje = session.GetString(key);
            if (string.IsNullOrEmpty(obje)) return null;
            T deserializedObje = JsonConvert.DeserializeObject<T>(obje);
            return deserializedObje;
        }
    }
}
