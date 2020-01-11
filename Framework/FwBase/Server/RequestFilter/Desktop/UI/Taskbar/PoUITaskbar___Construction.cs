using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoUITaskbar
    {
        static PoUITaskbar _instance;
        static readonly object _sync = new object();

        public static PoUITaskbar Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_sync)
                    {
                        if (_instance == null)
                        {
                            _instance = new PoUITaskbar();
                        }
                    }
                }
                return _instance;
            }
        }

        private PoUITaskbar()
        {
            var icons = CreateIconsLeft();
            var appsOpened = CreateIconsAppsOpened();
            var serverClock = CreateIconsServerClock();
            if (icons != null) Add(icons);
            if (appsOpened != null) Add(appsOpened);
            if (serverClock != null) Add(serverClock);

            ID = "taskbar";
            Model.Class = "taskbar";
        }
    }
}
