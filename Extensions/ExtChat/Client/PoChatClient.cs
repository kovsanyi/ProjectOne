using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ProjectOne
{
    public partial class PoChatClient
    {
        private readonly IPAddress _ipAddress;
        private readonly int _port;

        public PoChatClient(IPAddress ipAddress, int port)
        {
            _ipAddress = ipAddress;
            _port = port;
        }
    }
}
