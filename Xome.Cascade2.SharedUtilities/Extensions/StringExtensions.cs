using System;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Xome.Cascade2.SharedUtilities.Extensions
{
    public static class StringExtensions
    {
        public static T ToEnum<T>(this string value)
        {
            if (!Enum.IsDefined(typeof(T), value))
            {
                return default(T);
            }

            return (T)Enum.Parse(typeof(T), value);
        }

        //public static string GetDescription<T>(this T e) where T : IConvertible
        //{
        //    string result = null;
        //    if (e is Enum)
        //    {
        //        Type type = e.GetType();
        //        foreach (int value in Enum.GetValues(type))
        //        {
        //            ref T reference = ref e;
        //            T val = default(T);
        //            if (val == null)
        //            {
        //                val = reference;
        //                reference = ref val;
        //            }

        //            if (value == reference.ToInt32(CultureInfo.InvariantCulture))
        //            {
        //                object[] customAttributes = type.GetMember(type.GetEnumName(value))[0].GetCustomAttributes(typeof(DescriptionAttribute), inherit: false);
        //                if (customAttributes.Length != 0)
        //                {
        //                    result = ((DescriptionAttribute)customAttributes[0]).Description;
        //                }

        //                break;
        //            }
        //        }
        //    }

        //    return result;
        //}

        public static bool IsValidJson(this string text)
        {
            text = text.Trim();
            if ((text.StartsWith("{") && text.EndsWith("}")) || (text.StartsWith("[") && text.EndsWith("]")))
            {
                try
                {
                    JToken.Parse(text);
                    return true;
                }
                catch (JsonReaderException)
                {
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return false;
        }

        public static string ToSerializeString<T>(this T data) where T : class
        {
            return JsonConvert.SerializeObject(data);
        }

        public static byte[] ToBytes(this string data)
        {
            return Encoding.UTF8.GetBytes(data);
        }

        public static string FromBytes(this byte[] data)
        {
            if (data == null)
            {
                return null;
            }

            return Encoding.UTF8.GetString(data, 0, data.Length);
        }
    }
}
