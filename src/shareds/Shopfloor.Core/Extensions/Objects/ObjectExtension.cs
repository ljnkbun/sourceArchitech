﻿using System.Collections;
using System.Reflection;
using Newtonsoft.Json;

namespace Shopfloor.Core.Extensions.Objects
{
    public static class ObjectExtension
    {
        public static T Clone<T>(this T obj)
        {
            var serialized = JsonConvert.SerializeObject(obj);
            return JsonConvert.DeserializeObject<T>(serialized);
        }
        public static bool IsNullOrEmpty(this ICollection coll)
        {
            if (coll == null || coll.Count == 0) return true;
            return false;
        }
        public static bool IsNumber(this object value)
        {
            return value is sbyte
                    || value is byte
                    || value is short
                    || value is ushort
                    || value is int
                    || value is uint
                    || value is long
                    || value is ulong
                    || value is float
                    || value is double
                    || value is decimal;
        }
        public static string GetTrailingNumbers(this decimal _decimal)
        {
            decimal decimalNumbers = _decimal - Math.Round(_decimal, 0);
            if (decimalNumbers == 0) return string.Empty;

            return decimalNumbers.ToString().Split('.').LastOrDefault();
        }
        public static IDictionary<string, object> AsDictionary(this object source, string prefix = null, string suffix = null, BindingFlags bindingAttr = BindingFlags.Public | BindingFlags.Instance)
        {
            return source.GetType().GetProperties(bindingAttr).ToDictionary
            (
                propInfo => $"{prefix}{propInfo.Name}{suffix}",
                propInfo => propInfo.GetValue(source, null)
            );

        }

        public static object GetPropValue<T>(this T type, string field) where T : class
        {
            var property =
                type.GetType().GetProperties().FirstOrDefault(
                    pi => string.Equals(field, pi.Name, StringComparison.OrdinalIgnoreCase));
            return property != null ? property.GetValue(type) : string.Empty;
        }
        public static void TransferProperties<T>(this T obj, object target, IList<string> ignoreProperties = null)
        {
            var prods = obj.GetType().GetProperties();
            foreach (var prop in prods)
            {
                if (ignoreProperties?.Contains(prop.Name) == true)
                    continue;
                var ent = target.GetType().GetProperty(prop.Name);
                if (ent == null || !ent.CanRead) continue;
                var val = prop.GetValue(obj, null);
                ent.SetValue(target, val, null);
            }
        }
        public static void SetValue(this object obj, string fieldName, object value)
        {
            var prod = obj.GetType().GetProperty(fieldName);
            if (prod == null || !prod.CanRead) return;
            var t = prod.PropertyType;
            if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null || value.Equals(""))
                {
                    prod.SetValue(obj, null, null);
                    return;
                }
                t = Nullable.GetUnderlyingType(t);
            }
            var val = Convert.ChangeType(value, t);
            prod.SetValue(obj, val, null);
        }
    }
}
