using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoUIDesktop
    {
        protected bool IsLoaded;

        public void LoadIcons(IEnumerable<IPoApp> apps)
        {
            if (apps == null) return;
            Clear();
            foreach (var app in apps)
            {
                try
                {
                    var di = new PoUIDesktopIcon();
                    di.AppName = app.Name;
                    di.AppIcon = app.Icon;
                    di.AppPopup = app.Description;
                    di.AppLink = app.AppPrefix;
                    Add(di);
                }
                catch (Exception e)
                {
                    PoLogger.LogException(PoLogSource.Default, e, $"Could not load app icon: {app.Name}.");
                }
            }
        }
    }
}
