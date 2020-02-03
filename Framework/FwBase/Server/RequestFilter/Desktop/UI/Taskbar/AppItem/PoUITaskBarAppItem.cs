using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public partial class PoUITaskBarAppItem : PoUIHyperlink
    {
        public PoUITaskBarAppItem()
        {
            AddClass("app");
            Model.Href = "#app";
        }

        protected void SetValue()
        {
            var sb = new StringBuilder();
            sb.AppendLine(GetIconAsHtml());
            sb.AppendLine("<span>" + AppName + "</span>");
            //Model.Href = AppLink;
            Value = sb.ToString();
        }

        protected string GetIconAsHtml()
        {
            var icon = new PoUIImage();
            icon.Model.Source = "/resource/" + AppIcon;
            icon.Model.Width = "25px";
            var ret = icon.ToHtml();
            return ret;
        }
    }
}
