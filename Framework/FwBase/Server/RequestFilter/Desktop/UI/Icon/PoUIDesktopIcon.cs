using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public partial class PoUIDesktopIcon : PoUIHyperlink
    {
        public PoUIDesktopIcon()
        {
            AddClass("desktop-item");
        }

        protected void SetValue()
        {
            var sb = new StringBuilder();
            sb.AppendLine(GetIconAsHtml());
            sb.AppendLine("<span>" + AppName + "</span>");
            Model.Href = "/?App=" + AppLink;
            Value = sb.ToString();
        }

        protected string GetIconAsHtml()
        {
            var icon = new PoUIImage();
            icon.Model.Source = "/resource/" + AppIcon;
            icon.Model.Width = "40px";
            var ret = icon.ToHtml();
            return ret;
        }
    }
}
