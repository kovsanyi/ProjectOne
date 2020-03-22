using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoUIWindow
    {
        private void CreateHeader(string title, string iconScrName)
        {
            InitMinimizeBtn();
            InitCloseBtn();

            var btnContainer = new PoUILayout(PoOrientationType.Horizontal);
            btnContainer.AddClass("form-ctrl-btn-container");
            btnContainer.Add(ButtonMinimize);
            btnContainer.Add(ButtonClose);

            var header = new PoUILayout(PoOrientationType.Horizontal);
            header.AddClass("window-header");
            header.Style.SetStyle("padding", "0");
            header.Add(CreateTitle(iconScrName, title));
            header.Add(btnContainer);

            Add(header);
        }

        private PoUIComponent CreateTitle(string iconScrName, string title)
        {
            PoUIImage formIcon = null;
            if (iconScrName != null)
            {
                formIcon = new PoUIImage();
                formIcon.Model.Source = CreateResourceStr(iconScrName);
                formIcon.Model.Width = "25px";
                formIcon.Style.SetStyle("margin", "8px");
            }

            var formTitle = new PoUIHyperlink();
            formTitle.Style.SetStyle("margin", "auto 0");
            formTitle.Value = title;

            var container = new PoUILayout(PoOrientationType.Horizontal);
            container.AddClass("form-title");
            container.Style.SetStyle("padding", "0");
            if (formIcon != null) container.Add(formIcon);
            container.Add(formTitle);
            return container;
        }
    }
}
