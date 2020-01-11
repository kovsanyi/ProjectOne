using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ProjectOne
{
    partial class PoServerRoot
    {
        void handleRequest(object state)
        {
            var context = (HttpListenerContext)state;
            PoLogger.Log(PoLogSource.Default, PoLogType.Info, $"HTTP request received from: {context.Request.RemoteEndPoint.ToString()}, URI: {context.Request.Url}");
            //var data = new StreamReader(context.Request.InputStream, context.Request.ContentEncoding).ReadToEnd();
            //var dataCleaned = HttpUtility.UrlDecode(data);
            processRequest(context);
        }
    }
}
