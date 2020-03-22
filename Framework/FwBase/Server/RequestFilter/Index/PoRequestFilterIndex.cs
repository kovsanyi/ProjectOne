using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoRequestFilterIndex : IPoRequestFilter
    {
        public string Name => "Index";

        public bool ProcessRequest(PoHttpContext context)
        {
            if (context.Request.Url.AbsolutePath != "/") return false;
            context.Response.Redirect("/Desktop");
            context.Response.SendRedirect();
            return true;
        }
    }
}
