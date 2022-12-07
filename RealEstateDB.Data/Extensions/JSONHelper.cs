using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDB.Data.Extensions
{
    public static class JSONHelper
    {
        /// <summary>
        /// this method is used to serialize any object into json
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string ToJson(object sender)
        {
            if (sender == null)
                throw new Exception("Object cannot be null to serialize into json");

            return JsonConvert.SerializeObject(sender, Formatting.Indented);
        }
        /// <summary>
        /// this method takes json string and serializes it into the object passing the generic and returns list of those objects
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static List<T> JsonToList<T>(string json)
        {
            if (string.IsNullOrEmpty(json))
                throw new Exception("String cannot be null");

            return JsonConvert.DeserializeObject<List<T>>(json);
        }
        /// <summary>
        /// this method will serialize any object and transform it into the object passed into the generic
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static List<T>ToJsonToList<T>(object sender)
        {
            if (sender == null)
                return default;

            var json = ToJson(sender);
            return JsonToList<T>(json);
        }
    }
}
