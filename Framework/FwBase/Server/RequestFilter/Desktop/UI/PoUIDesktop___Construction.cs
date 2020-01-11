using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoUIDesktop
    {
        static PoUIDesktop _instance;
        static readonly object _sync = new object();

        public static PoUIDesktop Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_sync)
                    {
                        if (_instance == null)
                        {
                            _instance = new PoUIDesktop();
                        }
                    }
                }
                return _instance;
            }
        }

        private PoUIDesktop()
        {
            Model.Class = "desktop";
        }
    }
}
