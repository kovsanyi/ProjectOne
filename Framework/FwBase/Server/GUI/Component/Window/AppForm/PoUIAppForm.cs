using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public partial class PoUIAppForm : PoUIWindow
    {
        protected sealed override PoUIComponent Content { get => base.Content; set => base.Content = value; }

        public PoUIAppForm(IPoApp app, string pageName) : base(app.Name, app.Icon)
        {
            var toolbar = CreateToolbar(app);
            var page = CreatePage(app, pageName);

            var formContent = new PoUILayout();
            formContent.Add(toolbar);
            formContent.Add(page);

            Content = formContent;
        }
    }
}
