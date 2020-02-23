using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoLogger
    {
        public static PoLogType LogMode = PoLogType.Debug;

        public static void Log(IPoLogSource src, PoLogType t, string msg)
        {
            if ((byte)t < (byte)LogMode) return;
            if (src == null) return;
            var time = DateTime.Now;
            src.Log(time, t, msg);
        }

        public static void LogException(IPoLogSource src, Exception e, string msg = null, PoLogType t = PoLogType.Error)
        {
            Log(src, t, $"{msg} {e.Message}" + Environment.NewLine + e.StackTrace);
        }
    }
}
