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
            var model = (PoUIModelHyperlink)Model;
            model.Href = "/?App=" + AppLink;
            Value = sb.ToString();
        }

        protected string GetIconAsHtml()
        {
            var icon = new PoUIImage();
            var iconModel = (PoUIModelImage)icon.Model;
            iconModel.Source = "/resource/" + AppIcon;
            iconModel.Width = "40px";
            var ret = icon.Model.Model;
            return ret;
        }
    }
}
