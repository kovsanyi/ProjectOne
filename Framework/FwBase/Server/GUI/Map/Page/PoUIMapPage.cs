using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoUIMapPage
    {
        Dictionary<string, PoUIMapPageItem> _pageItems;

        public PoUIMapPage()
        {
            _pageItems = new Dictionary<string, PoUIMapPageItem>();
        }

        public void AddPage(string name, string title, Type type)
        {
            if (!typeof(PoUIComponent).IsAssignableFrom(type))
            {
                PoLogger.Log(PoLogSource.Default, PoLogType.Error,
                    $"Cannot register page because the type presented is not actually a UI component. Name: {name}. Type: {type.FullName}");
                return;
            }

            var item = new PoUIMapPageItem();
            item.Name = name;
            item.Title = title;
            item.PageType = type;

            if (!_pageItems.TryAdd(name, item))
                PoLogger.Log(PoLogSource.Default, PoLogType.Error,
                    $"Cannot register page with name '{name}' because an another item is already registered with this name.");
        }

        public bool TryGetPageByName(string name, out string title, out Type pageType)
        {
            title = null;
            pageType = null;
            if (name == null || !_pageItems.TryGetValue(name, out var component)) return false;
            title = component.Title;
            pageType = component.PageType;
            return true;
        }
    }
}
