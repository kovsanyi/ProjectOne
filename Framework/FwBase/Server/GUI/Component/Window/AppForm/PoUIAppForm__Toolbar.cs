using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoUIAppForm
    {
        private PoUIComponent CreateToolbar(IPoApp app)
        {
            var map = new PoUIMapToolbar();
            app.CreateToolbar(map);
            var items = map.GetItems();
            if (items == null || items.Count == 0) return null;
            var toolbar = new PoUILayout();
            foreach (var item in items)
            {
                var uiItem = CreateToolbarItem(item);
                toolbar.Add(uiItem);
            }
            return toolbar;
        }

        private PoUIComponent CreateToolbarItem(PoUIMapToolbarItem item)
        {
            return null;
        }
    }
}
