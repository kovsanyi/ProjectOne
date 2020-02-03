using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public interface IPoLogSource
    {
        void Log(DateTime time, PoLogType t, string msg);
    }
}
