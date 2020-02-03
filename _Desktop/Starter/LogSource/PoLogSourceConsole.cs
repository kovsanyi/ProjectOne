using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public partial class PoLogSourceConsole : PoLogSource
    {
        public override void Log(DateTime time, PoLogType t, string msg)
        {
            var line = CreateLineDefault(time, t, msg);
            setColor(t);
            Console.WriteLine(line);
        }

        void setColor(PoLogType t)
        {
            switch (t)
            {
                case PoLogType.Trace:
                case PoLogType.Debug:
                case PoLogType.Info:
                    if (Console.ForegroundColor == ConsoleColor.White) return;
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                case PoLogType.Warn:
                    if (Console.ForegroundColor == ConsoleColor.Blue) return;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    return;
                case PoLogType.Error:
                    if (Console.ForegroundColor == ConsoleColor.Red) return;
                    Console.ForegroundColor = ConsoleColor.Red;
                    return;
                default:
                    return;
            }
        }
    }
}
