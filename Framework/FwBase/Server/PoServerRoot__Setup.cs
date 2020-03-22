using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Authentication.ExtendedProtection;
using System.Text;

namespace ProjectOne
{
    partial class PoServerRoot
    {
        public const string LoginPage = "/Login";
        private HttpListener _listener;

        void setup()
        {
            if (!HttpListener.IsSupported)
            {
                PoLogger.Log(PoLogSource.Default, PoLogType.Error, "Cannot start root server due to HttpListener is not supported.");
                return;
            }
            _listener = new HttpListener();
            _listener.Prefixes.Add($"http://127.0.0.1:{PORT_RELEASE}/");
            _listener.AuthenticationSchemeSelectorDelegate = AuthenticationSchemeForClient;
            //_listener.ExtendedProtectionSelectorDelegate = ExtendedProtectionForClient;
        }

        private AuthenticationSchemes AuthenticationSchemeForClient(HttpListenerRequest httpRequest)
        {
            //if (httpRequest.RemoteEndPoint.Address.Equals(IPAddress.Loopback)) return AuthenticationSchemes.None;
            if (httpRequest.Url.AbsolutePath.StartsWith(LoginPage, StringComparison.InvariantCultureIgnoreCase))
                return AuthenticationSchemes.None;
            return AuthenticationSchemes.Basic;
        }
    }
}
