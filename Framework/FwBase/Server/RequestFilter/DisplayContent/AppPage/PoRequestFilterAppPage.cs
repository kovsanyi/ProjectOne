using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    class PoRequestFilterAppPage : IPoRequestFilter
    {
        public bool ProcessRequest(PoHttpContext context)
        {
            var appUrl = "/App/";
            var rawUrl = context.Request.RawUrl;
            if (!rawUrl.StartsWith(appUrl)) return false;
            var appPrefix = rawUrl.Remove(0, appUrl.Length);
            if (!PoDisplayContent.Instance.TryOpenAppPage(appPrefix, out var appPage)) return false;
            var appPageHTML = appPage.ToHTML();
            var appPageBytes = Encoding.UTF8.GetBytes(appPageHTML);
            context.Response.OutputStream.Write(appPageBytes, 0, appPageBytes.Length);
            return true;
        }
    }
}
