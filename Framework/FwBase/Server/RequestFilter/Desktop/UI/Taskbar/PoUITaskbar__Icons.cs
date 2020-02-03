using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoUITaskbar
    {
        protected PoUIComponent CreateStartMenu()
        {
            var a = new PoUIHyperlink();
            a.AddClass("start-menu");
            a.Model.Href = "#start-menu";

            var iconsLeft = new PoUILayout();
            iconsLeft.AddClass("icons-left");
            iconsLeft.Add(a);

            return iconsLeft;
        }

        protected PoUIComponent CreateIconsAppsOpened()
        {
            var appItems = new PoUILayout();
            appItems.AddClass("icons-app");
            foreach (var item in _appItems)
                appItems.Add(item);
            return appItems;
        }

        protected PoUIComponent CreateIconsServerClock()
        {
            PoUIComponent ret = null;
            return ret;
        }
    }
}
