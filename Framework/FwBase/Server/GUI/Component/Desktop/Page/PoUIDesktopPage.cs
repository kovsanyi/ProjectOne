using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoUIDesktopPage : PoUIPage
    {
        public PoUIDesktopPage() : this(null) { }

        public PoUIDesktopPage(PoUITaskbar taskbar) : base("Desktop")
        {
            var desktop = new PoUIDesktop();
            desktop.LoadIcons(PoAppManager.AppsMapped.Values);

            var content = new PoUILayout();
            content.Add(desktop);
            content.Add(taskbar);
            Body = content;
        }
    }
}
