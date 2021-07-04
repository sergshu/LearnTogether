using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributesTes
{
    class Helper
    {
        public static bool HasCustomAttribute(ITestItem o)
        {
            var attrs = o.GetType().GetCustomAttributes(false);
            return attrs.Any(a => a.GetType() == typeof(TestClassAttribute));
        }
    }
}
