using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace ProjectOne
{
    public partial class PoUIAppForm : PoUIWindow
    {
        protected sealed override PoUIComponent Content
        {
            get => base.Content;
            set => base.Content = value;
        }

        public PoUIAppForm(IPoApp app, string pageName) : base(app.Name, app.Icon)
        {
            var toolbar = CreateAppToolbar(app);
            var page = CreatePage(app, pageName);
            SetupFormButtons(app.AppPrefix);

            var formContent = new PoUILayout();
            formContent.Add(toolbar);
            formContent.Add(page);

            Content = formContent;
        }

        private void SetupFormButtons(string appName)
        {
            ButtonMinimize.Script.SetCustom(PoUIEventType.OnClick, "javascript:window.location.href='/Desktop'");
            ButtonClose.Script.SetCustom(PoUIEventType.OnClick, $"javascript:window.location.href='/Close?Name={HttpUtility.UrlEncode(appName)}'");
        }
    }
}
