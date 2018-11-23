using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalSetInventory.Data.Common
{
    public static class Extensions
    {
        public static Guid? ToGuid(this string value)
        {
            Guid guidValue;
            if (Guid.TryParse(value, out guidValue))
            {
                return guidValue;
            }
            return null;
        }
    }
}
