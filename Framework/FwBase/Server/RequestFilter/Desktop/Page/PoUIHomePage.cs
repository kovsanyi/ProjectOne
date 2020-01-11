using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoUIHomePage : PoUIPage
    {
        protected override List<PoUIHeadElement> HeadElements()
        {
            var list = base.HeadElements();
            list.Add(new PoUIHeadElementCSS("/resource/Desktop.css"));
            return list;
        }
        public PoUIHomePage()
        {
            var desktop = PoUIDesktop.Instance;
            Title = "Home";
            Body = desktop;
        }
    }
}
