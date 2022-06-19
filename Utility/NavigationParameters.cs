using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDemo.Utility
{
    public class NavigationParameters : Dictionary<string, object>
    {
        public bool TryGet<T>(string key, out T value)
        {
            if (ContainsKey(key) && this[key] is T v)
            {
                value = v;
                return true;
            }

            value = default;
            return false;
        }
    }
}
