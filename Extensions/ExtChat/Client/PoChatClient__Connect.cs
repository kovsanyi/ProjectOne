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
        private bool _connected;
        private PoConnectedClient _server;
        private Thread _serverThread;


        public void Connect()
        {
            if (_connected || _server != null && _serverThread.IsAlive)
            {
                PoLogger.Log(_logSource, PoLogType.Warn, $"Client already connected to {_ipAddress.MapToIPv4().ToString()}:{_port}");
                return;
            }

            //TODO validation
            _serverThread = new Thread(PerformConnection);
            _serverThread.IsBackground = true;
            _serverThread.Start();
            _connected = true;
        }

        public void Disconnect()
        {
            if (!_connected)
            {
                PoLogger.Log(_logSource, PoLogType.Warn, "Client already disconnected.");
                return;
            }
            _server.Client.Close();
            _connected = false;
            PoLogger.Log(_logSource, PoLogType.Info, $"Server {_server.ToString()} connection closed.");
        }

        private void PerformConnection()
        {
            try
            {
                var client = new TcpClient();
                client.Connect(_ipAddress, _port);
                _server = new PoConnectedClient(0, client);
                _server.Handle = new EventWaitHandle(false, EventResetMode.AutoReset);
                Read();
            }
            catch (Exception e) { PoLogger.LogException(_logSource, e); }
        }
    }
}
