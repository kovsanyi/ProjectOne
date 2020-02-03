using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    class PoRequestFilterAppPage : IPoRequestFilter
    {
        public bool ProcessRequest(PoHttpContext context)
        {
            var appUrl = "/?App=";
            var rawUrl = context.Request.RawUrl;
            if (!rawUrl.StartsWith(appUrl)) return false;
            var appPrefix = rawUrl.Remove(0, appUrl.Length);
            var pageName = "Home";
            var pageNameUrl = rawUrl.Remove(0, appUrl.Length + appPrefix.Length);
            if (!string.IsNullOrWhiteSpace(pageNameUrl))
            {
                var pageUrl = "&Page=";
                if (!pageNameUrl.StartsWith(pageUrl)) return false;
                pageName = pageNameUrl.Remove(0, pageUrl.Length);
                if (string.IsNullOrWhiteSpace(pageName)) return false;
            }

            if (!PoDisplayContent.Instance.TryOpenAppPage(appPrefix, pageName, out var appPage)) return false;
            var appPageHTML = appPage.ToHTML();
            var appPageBytes = Encoding.UTF8.GetBytes(appPageHTML);
            context.Response.OutputStream.Write(appPageBytes, 0, appPageBytes.Length);
            return true;
        }
    }
}
