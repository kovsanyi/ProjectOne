using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoUIMapMenu
    {
        Dictionary<string, PoUIMapMenuItem> _menuItems;

        public PoUIMapMenu()
        {
            _menuItems = new Dictionary<string, PoUIMapMenuItem>();
        }

        public PoUIMapMenuItem AddMenu(string name, string title, string icon, string toolTip)
        {
            var item = new PoUIMapMenuItem();
            item.Parent = null;
            item.PageName = name;
            item.Title = title;
            item.Icon = icon;
            item.ToolTip = toolTip;

            if (!_menuItems.TryAdd(name, item))
            {
                PoLogger.Log(PoLogSource.Default, PoLogType.Error,
                    $"Cannot register menu item with name '{name}' because an another item is already registered with this name.");
                return null;
            }
            return item;
        }

        public PoUIMapMenuItem AddSubmenu(PoUIMapMenuItem parent, string name, string title, string icon, string toolTip)
        {
            var item = new PoUIMapMenuItem();
            item.Parent = null;
            item.PageName = name;
            item.Title = title;
            item.Icon = icon;
            item.ToolTip = toolTip;

            if (!_menuItems.TryAdd(name, item))
            {
                PoLogger.Log(PoLogSource.Default, PoLogType.Error,
                    $"Cannot register submenu item with name '{name}' because an item is already registered with this name.");
                return null;
            }
            return item;
        }
    }
}
