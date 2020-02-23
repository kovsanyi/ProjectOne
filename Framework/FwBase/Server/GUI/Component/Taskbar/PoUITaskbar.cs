using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public partial class PoUITaskbar : PoUILayout
    {
        //DEBUG
        PoUILayout _icons;

        public PoUITaskbar()
        {
            Model.ID = "PoTaskbar";
            AddClass("taskbar");

            createTaskBar();
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
            Refresh();
        }
    }
}
