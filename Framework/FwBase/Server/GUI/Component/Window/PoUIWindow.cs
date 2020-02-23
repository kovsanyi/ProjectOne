using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoUIWindow : PoUILayout
    {
        public string Icon;

        PoUIComponent _content;
        protected virtual PoUIComponent Content
        {
            get => _content;
            set
            {
                _content = value;
                Refresh();
            }
        }

        public PoUIWindow(string title = null, string icon = null)
        {
            Icon = icon;
            AddClass("window");
            var header = createHeader(title);
            Add(header);
            Add(Content);
        }

        PoUIComponent createHeader(string titleVal)
        {
            var minimize = new PoUIHyperlink();
            //minimize.AddClass("window-form-button");
            minimize.AddClass("w3-button");
            minimize.Value = "_";
            minimize.Model.Href = "/Desktop";
            minimize.Script.InitScript(PoUIEventType.OnClick);
            minimize.Script.OnClick += ScriptOnClickMinimize;

            var close = new PoUIHyperlink();
            //close.AddClass("window-form-button");
            close.AddClass("w3-button");
            close.Value = "x";
            close.Script.InitScript(PoUIEventType.OnClick);
            close.Script.OnClick += ScriptOnClickClose;

            var title = new PoUIHyperlink();
            title.Value = titleVal;

            var btnContainer = new PoUILayout();
            btnContainer.AddClass("w3-display-topright");
            btnContainer.Add(minimize);
            btnContainer.Add(close);

            PoUIImage icon = null;
            if (Icon != null)
            {
                icon = new PoUIImage();
                icon.Model.Source = "/resource/" + Icon;
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

            return header;
        }

        private void ScriptOnClickMinimize(object sender, EventArgs e)
        {
            CallOnMinimize();
        }

        private void ScriptOnClickClose(object sender, EventArgs e)
        {
            CallOnClosed();
        }

        protected virtual void CallOnMinimize() { }

        protected virtual void CallOnClosed() { }
    }
}
