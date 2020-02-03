using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectOne
{
    public class PoUIMapToolbar
    {
        Dictionary<string, PoUIMapToolbarItem> _toolbarItems;
        public PoUIMapToolbar()
        {
            _toolbarItems = new Dictionary<string, PoUIMapToolbarItem>();
        }

        public void AddToolbarItem(string name, string title, string icon, string toolTip)
        {
            var item = new PoUIMapToolbarItem();
            item.PageName = name;
            item.Title = title;
            item.Icon = icon;
            item.ToolTip = toolTip;

            if (!_toolbarItems.TryAdd(name, item))
                PoLogger.Log(PoLogSource.Default, PoLogType.Error,
                    $"Cannot register toolbar item '{name}' because an another item is already registered with this name.");
        }

        public void AddSeparator() { }

        public void AddExit()
        {
            AddToolbarItem("Exit", "Exit", PoIcon.App_Exit, "Close the application");
        }

        public List<PoUIMapToolbarItem> GetItems()
        {
            var ret = _toolbarItems.Values.ToList();
            return ret;
        }
    }
}
