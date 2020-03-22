using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace ProjectOne
{
    public partial class PoConnection
    {
        private readonly byte[] _buffer = new byte[8192];
        private Socket _socket;
        private NetworkStream _stream;

        public bool Stop { get; private set; }

        public delegate void CallOnDisconnected();
        public event CallOnDisconnected OnDisconnected;

        public PoConnection() { }

        public void Start(Socket socket)
        {
            _socket = socket;
            _stream = new NetworkStream(_socket);
            var t = new Thread(Listen);
            t.Start();
        }

        public virtual void Terminate()
        {
            if (Stop) return;
            Stop = true;
            _stream.Dispose();
            _stream = null;
        }
    }
}
