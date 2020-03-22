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

            var desktopContaier = new PoUILayout();
            desktopContaier.AddClass("desktop-container");
            desktopContaier.Add(desktop);

            var wrapper = new PoUILayout();
            wrapper.AddClass("wrapper");
            wrapper.Model.ID = "PoWrapper";
            wrapper.Add(desktopContaier);
            wrapper.Add(taskbar);
            Body = wrapper;
        }
    }
}
