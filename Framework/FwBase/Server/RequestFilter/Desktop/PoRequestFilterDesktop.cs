using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectOne
{
    public class PoRequestFilterDesktop : IPoRequestFilter
    {
        public bool ProcessRequest(PoHttpContext context)
        {
            if (!context.Request.RawUrl.StartsWith("/Desktop")) return false;
            try
            {
                var apps = PoAppManager.AppsMapped.Values.ToList();
                PoUIDesktop.Instance.LoadIcons(apps);
                var html = new PoUIHomePage().ToHTML();
                var bytes = Encoding.UTF8.GetBytes(html);
                context.Response.SendChunked = true;
                context.Response.OutputStream.Write(bytes, 0, bytes.Length);
                return true;
            }
            catch (Exception e)
            {
                PoLogger.Log(PoLogSource.Default, PoLogType.Error, "Error while processing 'Desktop' request. Exception: " + e.Message);
                return false;
            }
        }
    }
}
