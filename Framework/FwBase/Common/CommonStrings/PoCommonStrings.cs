using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public static partial class PoCommonStrings
    {
        public static string GenerateRandomId(int length = 6)
        {
            var ret = GenerateRandomStr(length).ToUpperInvariant();
            return ret;
        }

        public static string GenerateRandomStr(int length = 8)
        {
            var builder = new StringBuilder();
            var random = new Random();
            char c;
            for (int i = 0; i < length; i++)
            {
                c = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(c);
            }
            var ret = builder.ToString().ToUpper();
            return ret;
        }
    }
}
