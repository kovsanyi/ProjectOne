using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ProjectOne
{
    internal class PoConnectedClient
    {
        internal int Id;
        internal TcpClient Client;
        internal NetworkStream Stream;
        internal byte[] Buffer;
        internal StringBuilder Data;
        internal EventWaitHandle Handle;

        public PoConnectedClient()
        {
            Data = new StringBuilder();
            Handle = new EventWaitHandle(false, EventResetMode.ManualReset);
        }
    }
}
