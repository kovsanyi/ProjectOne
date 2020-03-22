using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;
using System.Web;

namespace ProjectOne
{
    public class PoRequestFilterResource : IPoRequestFilter
    {
        public string Name => "Resource";

        public bool ProcessRequest(PoHttpContext context)
        {
            var path = context.Request.Url.AbsolutePath.ToLowerInvariant();
            if (!path.StartsWith("/resource/")) return false;
            var resourceName = path.Substring("/resource/".Length);
            if (!PoResourceManager.Instance.TryGetResource(resourceName, out var resBytes)) return false;
            SetContentType(context, resourceName);
            context.Response.AddHeader("Cache-Control", "max-age=120");
            context.Response.WriteBytesToOutput(resBytes);
            context.Response.SendSuccess();
            return true;
        }

        protected void SetContentType(PoHttpContext context, string resourceName)
        {
            if (SetContentType(context, resourceName, "text/css", ".css")) return;
            if (SetContentType(context, resourceName, "text/html", ".html")) return;
            if (SetContentType(context, resourceName, "text/javascript", ".js")) return;
            if (SetContentType(context, resourceName, "image/svg+xml", ".svg")) return;
            PoLogger.Log(PoLogSource.Default, PoLogType.Warn, $"Could not set content type for resource '{resourceName}'");
        }

        protected bool SetContentType(PoHttpContext context, string resourceName, string contentType, string extension)
        {
            if (!resourceName.EndsWith(extension)) return false;
            context.Response.SetContentType(contentType);
            return true;
        }
    }
}
