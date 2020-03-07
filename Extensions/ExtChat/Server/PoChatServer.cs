using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectOne
{
    public partial class PoChatServer : PoManagedItem
    {
        private readonly IPAddress _ipAddress;
        private readonly int _port;

        public PoChatServer() : this(null, -1) { }

        public PoChatServer(IPAddress ipAddress, int port) : base()
        {
            _ipAddress = ipAddress;
            _port = port;
        }
    }
}
