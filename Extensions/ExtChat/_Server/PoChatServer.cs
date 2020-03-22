using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectOne
{
    public partial class PoChatServer : PoManagedItem
    {
        private readonly int _port;

        public PoChatServer() : this(-1) { }

        public PoChatServer(int port) : base()
        {
            _port = port;
        }

        public Dictionary<string, PoConnectedStatus> GetConnectedUsers()
        {
            lock (_sync)
            {
                var usersOnline = _connections.ToDictionary(x => x.Username, x => PoConnectedStatus.Online);
                return usersOnline;
            }
        }
    }
}
