using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoRequestFilter : IPoRequestFilter
    {
        public bool ProcessRequest(PoHttpContext context)
        {
            foreach (var filer in Filters)
            {
                var isProcessed = filer.ProcessRequest(context);
                if (!isProcessed) continue;
                PoLogger.Log(PoLogSource.Default, PoLogType.Debug, "HTTP request processed by " + filer.GetType().Name);
                return true;
            }
            context.Response.SendNotFound();
            return false;
        }
    }
}
