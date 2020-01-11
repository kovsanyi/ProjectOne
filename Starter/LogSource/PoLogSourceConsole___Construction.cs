using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoLogSourceConsole
    {
        static PoLogSourceConsole _instance;
        static readonly object _sync = new object();

        public static PoLogSourceConsole Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_sync)
                    {
                        if (_instance == null)
                        {
                            _instance = new PoLogSourceConsole();
                        }
                    }
                }
                return _instance;
            }
        }

        private PoLogSourceConsole() : base() { }
    }
}
