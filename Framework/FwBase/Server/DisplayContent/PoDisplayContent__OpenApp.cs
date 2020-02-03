using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectOne
{
    partial class PoDisplayContent
    {
        public bool TryOpenAppPage(string appPrefix, string pageName, out PoUIPage appPage)
        {
            appPage = null;
            var app = PoAppManager.AppsMapped.Values.FirstOrDefault(x => x.AppPrefix == appPrefix);
            if (app == null) return false;
            getOrCreateAppWithPage(app, pageName, out appPage);
            return true;
        }

        void getOrCreateAppWithPage(IPoApp app, string pageName, out PoUIPage appPage)
        {
            if (_appsOpened.TryGetValue($"{app.AppPrefix}-{pageName}", out var appForm))
            {
                appPage = createPage(appForm, app.Name);
                return;
            }
            createAppWithPage(app, pageName, out appPage);
        }

        void createAppWithPage(IPoApp app, string pageName, out PoUIPage appPage)
        {
            var form = new PoUIAppForm(app, pageName);
            _appsOpened.TryAdd($"{app.AppPrefix}-{pageName}", form);
            PoUITaskbar.Instance.OpenApp(app);
            appPage = createPage(form, app.Name);
        }

        PoUIPage createPage(PoUIComponent content, string title)
        {
            var layout = new PoUILayout();
            layout.Add(content);
            layout.Add(PoUITaskbar.Instance);

            var page = new PoUIPage();
            page.Title = title;
            page.Body = layout;

            return page;
        }
    }
}
