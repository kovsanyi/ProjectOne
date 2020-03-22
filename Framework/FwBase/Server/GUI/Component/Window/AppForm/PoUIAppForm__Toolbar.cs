using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace ProjectOne
{
    partial class PoUIAppForm
    {
        private PoUIComponent CreateAppToolbar(IPoApp app)
        {
            var toolbar = CreateToolbar();
            var toolbarItems = CreateToolbarItems(app);
            if (toolbarItems.Count == 0) return null;
            toolbar.AddRange(toolbarItems);
            return toolbar;
        }

        private PoUILayout CreateToolbar()
        {
            var toolbar = new PoUILayout(PoOrientationType.Horizontal);
            toolbar.AddClass("app-form-toolbar");
            return toolbar;
        }

        private List<PoUIComponent> CreateToolbarItems(IPoApp app)
        {
            var items = new List<PoUIComponent>();
            var map = new PoUIMapToolbar();
            app.CreateToolbar(map);
            var mapItems = map.GetItems();
            if (mapItems == null || mapItems.Count == 0) return items;

            foreach (var mapItem in mapItems)
            {
                var toolbarItem = CreateToolbarItem(app, mapItem);
                items.Add(toolbarItem);
            }
            return items;
        }

        private PoUIComponent CreateToolbarItem(IPoApp app, PoUIMapToolbarItem item)
        {
            var img = new PoUIImage();
            img.Model.Source = CreateResourceStr(item.Icon);
            img.Style.SetStyle("width", "16px");
            img.Style.SetStyle("margin", "0 8px 0 0");

            var txt = new PoUISpan();
            txt.Model.ValueBetweenTags = item.Title;

            var btn = new PoUIButton();
            btn.AddClass("app-form-toolbar-item");
            btn.Model.ValueBetweenTags = img.ToHtml() + txt.ToHtml();
            btn.Script.SetCustom(PoUIEventType.OnClick, $"javascript:window.location.href='{CreateAppPageUrl(app, item)}'");
            return btn;
        }



        private string CreateAppPageUrl(IPoApp app, PoUIMapToolbarItem item)
        {
            var ret = $"{PoSessionContainer.RootUrlApp}?Name={app.AppPrefix}&Page={item.PageName}";
            ret = HttpUtility.HtmlEncode(ret);
            return ret;
        }
    }
}
