using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDB.Data.Extensions
{
    public static class PublicExtensions
    {
        public static string FormatWhereVariableName(this string sender)
        {
            if (string.IsNullOrEmpty(sender))
                return "null";
            else
                return $"'{sender}'";
        }
        public static string FormatWhereVariableName(this long? sender)
        {
            if (sender == null)
                return "null";
            else
                return $"{sender}";
        }
        public static string FormatWhereVariableName(this int? sender)
        {
            if (sender == null)
                return "null";
            else
                return $"{sender}";
        }
        public static string FormatWhereVariableName(this DateTime? sender)
        {
            if (sender == null)
                return "null";
            else
                return $"'{sender}'";
        }
        public static string FormatWhereVariableName(this double? sender)
        {
            if (sender == null)
                return "null";
            else
                return $"{sender}";
        }
        public static string ToJson(this object sender)
        {
            return JSONHelper.ToJson(sender);
        }
        public static List<T> JsonToList<T>(this string json)
        {
            return JSONHelper.JsonToList<T>(json);
        }
        public static List<T> ToJsonToList<T>(this object sender)
        {
            return JSONHelper.ToJsonToList<T>(sender);
        }
        public static T TransformModel<T>(this object sender)
        {
            if(sender == null)
            {
                return default;
            }
            List<object> holder = new();
            holder.Add(sender);
            var json = JSONHelper.ToJson(holder);
            var item = JSONHelper.JsonToList<T>(json);
            if(item != null && item.Count > 0)
                return item[0];

            return default;
        }
    }
}
