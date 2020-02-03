using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoUIWindow : PoUILayout
    {
        PoUIComponent _content;
        protected virtual PoUIComponent Content
        {
            get { return _content; }
            set
            {
                _content = value;
                IsDirty = true;
            }
        }

        public PoUIWindow()
        {
            AddClass("window");
            var header = createHeader();
            Add(header);
            Add(Content);
        }

        PoUIComponent createHeader()
        {
            var minimize = new PoUIHyperlink();
            minimize.AddClass("window-form-button");
            minimize.Scipt.InitScript(PoUIEventType.OnClick);
            minimize.Scipt.OnClick += SciptOnClickMinimize;

            var close = new PoUIHyperlink();
            close.AddClass("window-form-button");
            close.Scipt.InitScript(PoUIEventType.OnClick);
            close.Scipt.OnClick += SciptOnClickClose;
            close.Value = "x";

            var header = new PoUILayout();
            header.AddClass("window-header");
            header.Add(minimize);
            header.Add(close);
            return header;
        }

        private void SciptOnClickMinimize(object sender, EventArgs e)
        {
            CallOnMinimalize();
        }

        private void SciptOnClickClose(object sender, EventArgs e)
        {
            CallOnClosed();
        }

        protected virtual void CallOnMinimalize() { }

        protected virtual void CallOnClosed() { }
    }
}
