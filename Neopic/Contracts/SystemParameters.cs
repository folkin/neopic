using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neopic.Contracts
{
    public static class SystemParamters
    {
        private static IDictionary<string, string> _parameters = new Dictionary<string, string>();

        public static T Get<T>(string key)
        {
            return default(T);
        }

        public static void Set<T>(string key, T value)
        {
        }
    }
}
