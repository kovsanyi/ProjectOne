using System;
using System.Net;

namespace ProjectOne
{
    public partial class PoAppChatServer : IPoApp
    {
        public void CallOnOpened() { }

        public void CallOnClosed() { }

        public void CallOnStarted()
        {
            IPAddress.TryParse("127.0.0.1", out var ipAddress);
            var port = 2107;
            var server = new PoChatServer(ipAddress, port);
            server.Start();
        }

        public void CallOnStopped()
        {
            //PoChatServer.Instance.Stop();
        }
    }
}
