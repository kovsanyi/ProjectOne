using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace ProjectOne
{
    partial class PoChatServer
    {
        private readonly ConcurrentDictionary<int, PoConnectedClient> _clientsConnected =
            new ConcurrentDictionary<int, PoConnectedClient>();

        private int _availableId = 0;

        private void StartListenerAsync()
        {
            PoBackgroundJob.Enqueue(() => StartListener(), "PoChatServer/StartListenerAsync");
        }

        private void StartListener()
        {
            var listener = new TcpListener(_ipAddress, _port);
            listener.Start();
            _active = true;

            try
            {
                while (_active)
                {
                    if (listener.Pending())
                    {
                        var client = new PoConnectedClient(_availableId++, listener.AcceptTcpClient());
                        var msg = new PoChatServerMessage(client.Client.Client.RemoteEndPoint.ToString(),
                            client.Client.Client.LocalEndPoint.ToString(),
                            "Client connected from " + client.Client.Client.RemoteEndPoint.ToString());
                        PoChatServerMessageManager.Instance.Add(msg);
                        _clientsConnected.TryAdd(client.Id, client);
                        var thread = new Thread(() => ManageConnection(client));
                        thread.IsBackground = true;
                        thread.Start();
                    }
                    else
                    {
                        //TODO megszűntetni!
                        Thread.Sleep(500);
                    }
                }
                //listener.Stop();
                listener.Server.Close();
                _active = false;
            }
            catch (Exception e)
            {
                PoLogger.LogException(_logSource, e);
            }
        }
    }
}
