using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ProjectOne
{
    public class PoRequestFilterUic : IPoRequestFilter
    {
        public bool ProcessRequest(PoHttpContext context)
        {
            var url = context.Request.Url.AbsolutePath.ToLowerInvariant();
            if (!url.StartsWith("/desktop") && !url.StartsWith("/app")) return false;
            PoHttpSessionManager.Instance.HandleRequest(context);
            return true;
        }
    }
}
