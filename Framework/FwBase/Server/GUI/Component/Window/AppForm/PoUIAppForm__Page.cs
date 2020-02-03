using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoUIAppForm
    {
        PoUIComponent createPage(IPoApp app, string pageName)
        {
            var map = new PoUIMapPage();
            app.CreatePages(map);
            if (!map.TryGetPageByName(pageName, out var title, out var pageType)) return null;
            try
            {
                var page = (PoUIComponent)Activator.CreateInstance(pageType);
                return page;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
