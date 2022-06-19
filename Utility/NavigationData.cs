using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDemo.Utility
{
    public static class NavigationData
    {
        public static NavigationParameters GetDefaultSetupParams()
            => new()
            {
                { "username", "user" },
                { "password", "password" },
                { "domain", Config.UrlSubDomain }
            };
    }
}
