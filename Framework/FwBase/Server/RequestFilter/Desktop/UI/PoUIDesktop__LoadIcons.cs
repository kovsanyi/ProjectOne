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
            if (apps == null || IsLoaded) return;
            foreach (var app in apps)
            {
                try
                {
                    var item = new PoUIDesktopIcon();
                    item.AppName = app.Name;
                    item.AppIcon = app.Icon;
                    item.AppPopup = app.Description;
                    item.AppLink = app.AppPrefix;
                    Add(item);
                }
                catch (Exception e)
                {
                    PoLogger.Log(PoLogSource.Default, PoLogType.Error, "Could not load app icon: " + app.Name + ". Exception: " + e.Message);
                }
            }
            IsLoaded = true;
        }
    }
}
