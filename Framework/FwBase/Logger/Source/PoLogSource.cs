using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public abstract class PoLogSource : IPoLogSource
    {
        public static IPoLogSource Default;

        public virtual void Log(DateTime time, PoLogType t, string msg) { }

        protected string CreateLineDefault(DateTime time, PoLogType t, string msg)
        {
            var ret = time.ToString("yyyy-MM-dd HH:mm:ss") + " " + ConvertLogTypeToStr(t) + " " + msg;
            return ret;
        }

        protected string ConvertLogTypeToStr(PoLogType t)
        {
            string ret;
            switch (t)
            {
                case PoLogType.Trace:
                    ret = "[TRAC]";
                    break;
                case PoLogType.Debug:
                    ret = "[DEBU]";
                    break;
                case PoLogType.Info:
                    ret = "[INFO]";
                    break;
                case PoLogType.Warn:
                    ret = "[WARN]";
                    break;
                case PoLogType.Error:
                    ret = "[ERRO]";
                    break;
                default:
                    ret = "[????]";
                    break;
            }
            return ret;
        }
    }
}
