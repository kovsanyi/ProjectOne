//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace ProjectOne
//{
//    public class PoWebDisplayRequest_AppOpen : IPoWebDisplayRequest
//    {
//        private string _appName;

//        public PoWebDisplayRequest_AppOpen(string appName)
//        {
//            _appName = appName;
//        }

//        public void Process(PoHttpContext context, Dictionary<string, PoUIComponent> components)
//        {

//            if (!PoWebDisplay.Instance.TryOpenAppPage(appPrefix, pageName, out var appPage)) return false;
//            var appPageHTML = appPage.ToHTML();
//            var appPageBytes = Encoding.UTF8.GetBytes(appPageHTML);
//            context.Response.OutputStream.Write(appPageBytes, 0, appPageBytes.Length);
//            return true;
//        }

//        public bool TryOpenAppPage(string appPrefix, string pageName, out PoUIPage appPage)
//        {
//            appPage = null;
//            var app = PoAppManager.AppsMapped.Values.FirstOrDefault(x => x.AppPrefix == appPrefix);
//            if (app == null) return false;
//            GetOrCreateAppWithPage(app, pageName, out appPage);
//            return true;
//        }

//        private void GetOrCreateAppWithPage(IPoApp app, string pageName, out PoUIPage appPage)
//        {
//            if (_componentsOnDisplay.TryGetValue($"{app.AppPrefix}-{pageName}", out var appForm))
//            {
//                appPage = CreatePage(appForm, app.Name);
//                return;
//            }
//            CreateAppWithPage(app, pageName, out appPage);
//        }

//        private void CreateAppWithPage(IPoApp app, string pageName, out PoUIPage appPage)
//        {
//            var form = new PoUIAppForm(app, pageName);
//            _componentsOnDisplay.TryAdd($"{app.AppPrefix}-{pageName}", form);
//            PoUITaskbar.Instance.OpenApp(app);
//            appPage = CreatePage(form, app.Name);
//        }

//        private PoUIPage CreatePage(PoUIComponent content, string title)
//        {
//            var layout = new PoUILayout();
//            layout.Add(content);
//            layout.Add(PoUITaskbar.Instance);

//            var page = new PoUIPage();
//            page.Title = title;
//            page.Body = layout;

//            return page;
//        }

//    }
//}
