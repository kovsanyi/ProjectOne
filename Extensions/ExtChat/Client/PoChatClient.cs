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
        private Thread _serverThread;
        private PoConnectedClient _server;
        private bool _connected;

        public PoChatClient()
        {

        }
    }
}
