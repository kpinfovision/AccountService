using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xome.Cascade2.SharedUtilities.Extensions
{
    public static class InterfaceExtensions
    {
        public static object GetPropertyValue<T>(this T i, string propertyName) where T : class
        {
            return i?.GetType()?.GetProperty(propertyName)?.GetValue(i, null);
        }

        public static object GetResponseEnvelope<T>(this T i) where T : class
        {
            return i?.GetType()?.GetProperty("ResponseEnvelope")?.GetValue(i, null);
        }

        public static object GetPaginationEnvelope<T>(this T i) where T : class
        {
            return i?.GetType()?.GetProperty("PaginationEnvelope")?.GetValue(i, null);
        }
    }
}
