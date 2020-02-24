using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectOne
{
    public partial class PoChatServer
    {
        private readonly ConcurrentDictionary<int, PoConnectedClient> _clientsConnected =
            new ConcurrentDictionary<int, PoConnectedClient>();
        private bool _active;
        private Thread _listenerThread;
        private IPAddress _serverAddr;
        private int _serverPort;
        private Task _send;

        public void Start()
        {
            if (_active)
            {
                _active = false;
            }
            else
            {
                if (_listenerThread != null && _listenerThread.IsAlive) return;
                if (_serverPort < 0 || _serverPort > 65535) return;
                //TODO
            }
        }

        public void Stop()
        {
            //TODO
        }
    }
}
