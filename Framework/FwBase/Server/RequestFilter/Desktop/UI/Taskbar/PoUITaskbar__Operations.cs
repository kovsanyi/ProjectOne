using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoUITaskbar
    {
        List<PoUITaskBarAppItem> _appItems;

        public void OpenApp(IPoApp app)
        {
            var item = new PoUITaskBarAppItem();
            item.AppName = app.Name;
            item.AppIcon = app.Icon;
            _appItems.Add(item);
            createTaskBar();
        }

        public void CloseApp(IPoApp app)
        {

        }
    }
}
