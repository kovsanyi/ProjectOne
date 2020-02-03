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
                FinalizeRequest(context, true);
                PoLogger.Log(PoLogSource.Default, PoLogType.Info, "HTTP request processed by " + filer.GetType().Name);
                return true;
            }
            FinalizeRequest(context, false);
            return false;
        }

        void FinalizeRequest(PoHttpContext context, bool success)
        {
            try
            {
                if (success)
                {
                    context.Response.StatusCode = 200;
                    context.Response.StatusDescription = "OK";
                }
                else
                {
                    context.Response.StatusCode = 404;
                    context.Response.StatusDescription = "OK";
                }
                context.Response.Close();
            }
            catch (ObjectDisposedException) { }
        }
    }
}
