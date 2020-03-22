using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ProjectOne
{
    partial class PoAppChatClient
    {
        private static object Sync = new object();
        private static bool _created;
        public static PoChatClient ChatClient;

        public static void InitChatClientIfNotInitialized(string username, string domain, string password)
        {
            if (_created) return;
            lock (Sync)
            {
                if (_created) return;
                if (!IPAddress.TryParse(domain, out var ipAddr)) return;
                //var ipAddr = Dns.GetHostAddresses(domain)[0];
                ChatClient = new PoChatClient(ipAddr, 2107);
                //ChatClient.SendLoginRequest(username, password);
                _created = true;
            }
        }
    }
}
