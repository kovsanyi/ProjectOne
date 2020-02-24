using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ProjectOne
{
    partial class PoChatClient
    {
        public void Connect(IPAddress ipAddr, int port)
        {
            if (_connected) //TODO
            {
                _server.Client.Close();
                return;
            }

            if (_server != null && _serverThread.IsAlive) return;
            _serverThread = new Thread(() => Connection(ipAddr, port));
            _serverThread.IsBackground = true;
            _serverThread.Start();
        }

        private void Connection(IPAddress ipAddr, int port)
        {
            try
            {
                _server = new PoConnectedClient();
                _server.Client = new TcpClient();
                _server.Client.Connect(ipAddr, port);
                _server.Stream = _server.Client.GetStream();
                _server.Handle = new EventWaitHandle(false, EventResetMode.AutoReset);
                if (_server.Stream.CanRead && _server.Stream.CanWrite)
                {
                    try
                    {
                        _server.Stream.BeginRead(_server.Buffer, 0, _server.Buffer.Length, Read, null);
                        _server.Handle.WaitOne();
                    }
                    catch (Exception e) { }
                }
            }
            catch (Exception e) { }
        }
    }
}
