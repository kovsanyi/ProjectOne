using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ProjectOne
{
    partial class PoServerRoot
    {
        HttpListener _listener;
        void setup()
        {
            if (!HttpListener.IsSupported)
            {
                PoLogger.Log(PoLogSource.Default, PoLogType.Error, "Cannot start root server due to HttpListener is not supported.");
                return;
            }
            _listener = new HttpListener();
            _listener.Prefixes.Add($"http://127.0.0.1:{PORT_RELEASE}/");
            _listener.AuthenticationSchemes = AuthenticationSchemes.Basic;
        }
    }
}
