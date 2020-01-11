using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;

namespace ProjectOne
{
    public class PoRequestFilterClientAction : IPoRequestFilter
    {
        public bool ProcessRequest(PoHttpContext context)
        {
            if (!context.Request.RawUrl.StartsWith("/clientAction")) return false;
            try
            {
                var queryParams = ParseQueryString(context.Request.QueryString);
                if (!queryParams.TryGetValue("id", out var id)) return false;
                if (!queryParams.TryGetValue("eventType", out var eventType)) return false;
                var respStr = "[DEBUG] Client action received for id=" + id + " with eventType=" + eventType + ". Reuest processed.";
                var respBytes = Encoding.UTF8.GetBytes(respStr);
                context.Response.OutputStream.Write(respBytes, 0, respBytes.Length);
                return true;
            }
            catch (Exception e)
            {
                PoLogger.Log(PoLogSource.Default, PoLogType.Error, "Error while processing 'ClientAction' request. Exception: " + e.Message);
                return false;
            }


        }
        public Dictionary<string, string> ParseQueryString(NameValueCollection nvc)
        {
            //var nvc = HttpUtility.ParseQueryString(queryString);
            var ret = nvc.AllKeys.ToDictionary(k => k, k => nvc[k]);
            return ret;
        }
    }
}
