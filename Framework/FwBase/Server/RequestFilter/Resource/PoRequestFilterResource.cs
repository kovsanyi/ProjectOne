using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;
using System.Web;

namespace ProjectOne
{
    public class PoRequestFilterResource : IPoRequestFilter
    {
        public bool ProcessRequest(PoHttpContext context)
        {
            var decoded = HttpUtility.UrlDecode(context.Request.RawUrl);
            var url = decoded.TrimStart('/');
            if (!url.StartsWith("resource/")) return false;
            var resName = url.Remove(0, "resource/".Length);
            if (!PoResourceManager.Instance.TryGetResource(resName, out var resBytes)) return false;
            SetContentType(context, resName);
            context.Response.AddHeader("Cache-Control", "max-age=120");
            context.Response.SendChunked = true;
            context.Response.OutputStream.Write(resBytes, 0, resBytes.Length);
            return true;
        }

        protected void SetContentType(PoHttpContext context, string resName)
        {
            if (SetContentType(context, resName, "text/css", ".css")) return;
            if (SetContentType(context, resName, "text/html", ".html")) return;
            if (SetContentType(context, resName, "text/javascript", ".js")) return;
            if (SetContentType(context, resName, "image/svg+xml", ".svg")) return;
            PoLogger.Log(PoLogSource.Default, PoLogType.Warn, "Could not set content type for resource: " + resName);
        }

        protected bool SetContentType(PoHttpContext context, string resName, string contentType, string extension)
        {
            if (!resName.EndsWith(extension)) return false;
            context.Response.ContentType = contentType;
            return true;
        }
    }
}
