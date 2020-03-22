using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoUIWindow
    {
        protected PoUILayout ButtonMinimize;
        protected PoUILayout ButtonClose;

        private void InitMinimizeBtn()
        {
            ButtonMinimize = new PoUILayout();
            ButtonMinimize.AddClass("form-ctrl-btn");
            ButtonMinimize.AddClass("form-ctrl-btn-minimize");
            ButtonMinimize.Script.InitScript(PoUIEventType.OnClick);
            ButtonMinimize.Script.OnClick += ScriptOnClickMinimize;
        }

        private void InitCloseBtn()
        {
            ButtonClose = new PoUILayout();
            ButtonClose.AddClass("form-ctrl-btn");
            ButtonClose.AddClass("form-ctrl-btn-close");
            ButtonClose.Script.InitScript(PoUIEventType.OnClick);
            ButtonClose.Script.OnClick += ScriptOnClickClose;
        }

        private void ScriptOnClickMinimize(object sender, PoHttpRequest req)
        {
            CallOnMinimize(req);
        }

        private void ScriptOnClickClose(object sender, PoHttpRequest req)
        {
            CallOnClosed(req);
        }

        protected virtual void CallOnMinimize(PoHttpRequest req) { }

        protected virtual void CallOnClosed(PoHttpRequest req) { }
    }
}
