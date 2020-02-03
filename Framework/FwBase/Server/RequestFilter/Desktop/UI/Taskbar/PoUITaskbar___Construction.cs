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

        //DEBUG
        PoUILayout _icons;
        private PoUITaskbar()
        {
            _appItems = new List<PoUITaskBarAppItem>();
            createTaskBar();

            ID = "taskbar";
            AddClass("taskbar");
        }

        void createTaskBar()
        {
            Clear();
            _icons = new PoUILayout();
            _icons.AddClass("icons");
            var icons = CreateStartMenu();
            var appsOpened = CreateIconsAppsOpened();
            var serverClock = CreateIconsServerClock();
            if (icons != null) _icons.Add(icons);
            if (appsOpened != null) _icons.Add(appsOpened);
            if (serverClock != null) _icons.Add(serverClock);
            Add(_icons);
        }
    }
}
