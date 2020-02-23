using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoUITaskbar
    {
        private readonly Dictionary<string, PoUITaskBarAppEntry> _appItems = new Dictionary<string, PoUITaskBarAppEntry>();

        public void OpenApp(IPoApp app)
        {
            var item = new PoUITaskBarAppEntry();
            item.AppName = app.Name;
            item.AppIcon = app.Icon;
            _appItems.TryAdd(app.AppPrefix, item);
            createTaskBar();
        }

        public void CloseApp(IPoApp app)
        {
            _appItems.Remove(app.AppPrefix);
            createTaskBar();
        }

        public override string ToHtml()
        {
            return base.ToHtml();
        }
    }
}
