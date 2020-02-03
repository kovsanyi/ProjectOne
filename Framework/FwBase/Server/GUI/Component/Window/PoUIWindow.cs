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
            minimize.Events.InitScript(PoUIEventType.OnClick);
            minimize.Events.OnClick += Events_OnClickMinimize;

            var close = new PoUIHyperlink();
            close.AddClass("window-form-button");
            close.Events.InitScript(PoUIEventType.OnClick);
            close.Events.OnClick += Events_OnClickClose;
            close.Value = "x";

            var header = new PoUILayout();
            header.AddClass("window-header");
            header.Add(minimize);
            header.Add(close);
            return header;
        }

        private void Events_OnClickMinimize(object sender, EventArgs e)
        {
            CallOnMinimalize();
        }

        private void Events_OnClickClose(object sender, EventArgs e)
        {
            CallOnClosed();
        }

        protected virtual void CallOnMinimalize() { }

        protected virtual void CallOnClosed() { }
    }
}
