﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoUIWindow
    {
        private void CreateHeader(string titleVal, string iconSrc)
        {
            var minimize = CreateMinimizeBtn();
            var close = CreateCloseBtn();

            var title = new PoUIHyperlink();
            title.Value = titleVal;

            var btnContainer = new PoUILayout();
            btnContainer.AddClass("w3-display-topright");
            btnContainer.Add(minimize);
            btnContainer.Add(close);

            PoUIImage icon = null;
            if (iconSrc != null)
            {
                icon = new PoUIImage();
                icon.Model.Source = "/resource/" + iconSrc;
                icon.Model.Width = "25px";
                icon.Style.SetStyle("margin", "8px");
            }

            var titleContainer = new PoUILayout();
            titleContainer.Style.SetStyle("padding", "0");
            titleContainer.AddClass("w3-container");
            titleContainer.Add(icon);
            titleContainer.Add(title);

            var header = new PoUILayout();
            header.AddClass("window-header");
            header.AddClass("w3-container");
            header.Style.SetStyle("padding", "0");
            header.Add(titleContainer);
            header.Add(btnContainer);

            Add(header);
        }

        private PoUIComponent CreateMinimizeBtn()
        {
            var minimize = new PoUIHyperlink();
            //minimize.AddClass("window-form-button");
            minimize.AddClass("w3-button");
            minimize.Value = "_";
            minimize.Model.Href = "/Desktop";
            minimize.Script.InitScript(PoUIEventType.OnClick);
            minimize.Script.OnClick += ScriptOnClickMinimize;
            return minimize;
        }

        private PoUIComponent CreateCloseBtn()
        {
            var close = new PoUIHyperlink();
            //close.AddClass("window-form-button");
            close.AddClass("w3-button");
            close.Value = "x";
            close.Script.InitScript(PoUIEventType.OnClick);
            close.Script.OnClick += ScriptOnClickClose;
            return close;
        }

        private void ScriptOnClickMinimize(object sender, PoHttpRequest e)
        {
            CallOnMinimize();
        }

        private void ScriptOnClickClose(object sender, PoHttpRequest e)
        {
            CallOnClosed();
        }

        protected virtual void CallOnMinimize() { }

        protected virtual void CallOnClosed() { }
    }
}
