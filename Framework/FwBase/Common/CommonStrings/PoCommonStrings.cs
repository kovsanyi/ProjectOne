using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public static partial class PoCommonStrings
    {
        public static string GenerateRandomStr()
        {
            var builder = new StringBuilder();
            var random = new Random();
            char c;
            for (int i = 0; i < 8; i++)
            {
                c = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(c);
            }
            var ret = builder.ToString().ToUpper();
            return ret;
        }
    }
}
