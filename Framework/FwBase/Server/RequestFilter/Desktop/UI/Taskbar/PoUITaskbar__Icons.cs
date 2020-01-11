using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoUITaskbar
    {
        protected PoUIComponent CreateIconsLeft()
        {
            var a = new PoUIHyperlink();
            var model = (PoUIModelHyperlink)a.Model;
            model.Href = "#start-menu";
            model.Class = "start-menu";

            var iconsLeft = new PoUILayout();
            iconsLeft.Model.Class = "icons-left";
            iconsLeft.Add(a);

            var icons = new PoUILayout();
            icons.Model.Class = "icons";
            icons.Add(iconsLeft);

            return icons;
        }

        protected PoUIComponent CreateIconsAppsOpened()
        {
            PoUIComponent ret = null;
            return ret;
        }

        protected PoUIComponent CreateIconsServerClock()
        {
            PoUIComponent ret = null;
            return ret;
        }
    }
}
