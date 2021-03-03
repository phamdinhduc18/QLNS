using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QLNS.Helpers.Extensions
{
    public static class ObjectExtensions
    {
        public static T GetValueByPropertyName<T>(this object obj, string propertyName) where T: class
        {
            try
            {
                var type = obj.GetType();
                foreach(var p in type.GetProperties())
                {
                    var t = p.GetValue(obj, null);
                    Debug.WriteLine(t);
                }
                var result =type.GetProperty(propertyName).GetValue(obj, null);
                return result as T;
            }
            catch
            {
                return default;
            }
        }

    }
}
