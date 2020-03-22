using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoUIAppForm
    {
        private PoUIComponent CreatePage(IPoApp app, string pageName)
        {
            var map = new PoUIMapPage();
            app.CreatePages(map);

            if (!map.TryGetPageByName(pageName, out var title, out var pageType)) return null;
            try
            {
                var page = (PoUIComponent)Activator.CreateInstance(pageType);
                page.AddClass("app-form-content");
                return page;
            }
            catch (Exception e)
            {
                PoLogger.LogException(PoLogSource.Default, e,
                    $"Cannot create page content of app {app.GetType().Namespace}.");
                return null;
            }
        }
    }
}
