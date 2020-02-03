using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoUIAppForm
    {
        PoUIComponent createToolbar(IPoApp app)
        {
            var map = new PoUIMapToolbar();
            app.CreateToolbar(map);
            var items = map.GetItems();
            var toolbar = new PoUILayout();
            foreach (var item in items)
            {
                var uiItem = createToolbarItem(item);
                toolbar.Add(uiItem);
            }
            return toolbar;
        }

        PoUIComponent createToolbarItem(PoUIMapToolbarItem item)
        {
            return null;
        }
    }
}
