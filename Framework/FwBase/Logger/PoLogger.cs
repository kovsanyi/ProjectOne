using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoLogger
    {
        public static void Log(IPoLogSource src, PoLogType t, string msg)
        {
            if (src == null) return;
            var time = DateTime.Now;
            src.Log(time, t, msg);
        }
    }
}
