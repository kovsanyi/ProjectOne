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
            ((PoUIModelHyperlink)Model).Href = "#app";
        }

        protected void SetValue()
        {
            var sb = new StringBuilder();
            sb.AppendLine(GetIconAsHtml());
            sb.AppendLine("<span>" + AppName + "</span>");
            var model = (PoUIModelHyperlink)Model;
            //model.Href = AppLink;
            Value = sb.ToString();
        }

        protected string GetIconAsHtml()
        {
            var icon = new PoUIImage();
            var iconModel = (PoUIModelImage)icon.Model;
            iconModel.Source = "/resource/" + AppIcon;
            iconModel.Width = "25px";
            var ret = icon.Model.Model;
            return ret;
        }
    }
}
