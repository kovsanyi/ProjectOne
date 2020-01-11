using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ProjectOne
{
    partial class PoServerRoot
    {
        void processRequest(HttpListenerContext context)
        {
            var poContext = new PoHttpContext(context);
            PoRequestFilter.Instance.ProcessRequest(poContext);
        }

        bool loginPage(HttpListenerContext context)
        {
            if (!PoResourceManager.Instance.TryGetResource("login.html", out var loginHtmlBytes)) return false;
            context.Response.OutputStream.Write(loginHtmlBytes, 0, loginHtmlBytes.Length);
            return true;
        }

    }
}
