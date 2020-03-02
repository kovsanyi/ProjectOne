using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public partial class PoUIAppForm : PoUIWindow
    {
        protected sealed override PoUIComponent Content { get => base.Content; set => base.Content = value; }

        //protected virtual PoUIComponent Content2 { get; set; }

        public override List<PoUIHeadElement> HeadElements()
        {
            var headElements = base.HeadElements();
            headElements.Add(new PoUIHeadElementCSS("/resource/window.css"));
            return headElements;
        }

        public PoUIAppForm(IPoApp app, string pageName) : base(app.Name, app.Icon)
        {
            var toolbar = createToolbar(app);
            var page = createPage(app, pageName);

            var wrapper = new PoUILayout();
            wrapper.Add(toolbar);
            wrapper.Add(page);
            //wrapper.Add(Content2);

            Content = wrapper;
            var tostr = ToHtml();
        }
    }
}
