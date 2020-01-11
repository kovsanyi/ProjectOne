using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoRequestFilterPage : IPoRequestFilter
    {
        public bool ProcessRequest(PoHttpContext context)
        {
            //TODO
            if (context.Request.RawUrl != "/") return false;
            context.Response.Redirect("/Desktop");
            context.Response.Close();
            return true;
            var pageLogin = new PoUIPageLogin();
            var htmlPage = pageLogin.ToHTML().Trim();//.Replace("\r", "").Replace("\n", "");
            var bytes = Encoding.UTF8.GetBytes(htmlPage);
            context.Response.SendChunked = true;
            context.Response.OutputStream.Write(bytes, 0, bytes.Length);
            return true;
        }
    }
}
