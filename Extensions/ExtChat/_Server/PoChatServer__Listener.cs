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
        //private readonly ConcurrentDictionary<int, PoConnectedClient> _clientsConnected =
        //    new ConcurrentDictionary<int, PoConnectedClient>();

        private readonly List<PoChatWorker> _connections = new List<PoChatWorker>();

        private int _availableId = 0;

        private void StartListenerAsync()
        {
            PoBackgroundJob.Enqueue(() => StartListener(), "PoChatServer/StartListenerAsync");
        }

        private void StartListener()
        {
            try
            {
                var listener = new TcpListener(IPAddress.Any, _port);
                listener.Start();
                OnServerStarted?.Invoke();
                _active = true;
                while (_active)
                {
                    if (listener.Pending())
                    {
                        var socket = listener.AcceptSocket();
                        var client = new PoChatWorker($"Client{_availableId++}", socket, this);
                        lock (_sync)
                        {
                            _connections.Add(client);
                            client.Start(socket);
                            //OnUserConnected?.Invoke(client.Username);
                        }
                    }
                    else
                    {
                        Thread.Sleep(500);
                    }
                }
                listener.Server.Close();
            }
            catch (Exception e) { PoLogger.LogException(PoLogSource.Default, e); }
            finally { OnServerStopped?.Invoke(); }
        }

        public void Terminate()
        {
            lock (_sync)
            {
                _active = false;
                foreach (var connection in _connections)
                {
                    connection.Terminate();
                }
            }
        }

        //private void StartListener()
        //{
        //    var listener = new TcpListener(IPAddress.Loopback, _port);
        //    listener.Start();
        //    OnServerStarted?.Invoke();
        //    _active = true;

        //    try
        //    {
        //        while (_active)
        //        {
        //            if (listener.Pending())
        //            {
        //                var client = new PoConnectedClient(_availableId++, listener.AcceptTcpClient());
        //                var msg = new PoChatServerMessage(client.Client.Client.RemoteEndPoint.ToString(),
        //                    client.Client.Client.LocalEndPoint.ToString(),
        //                    "Client connected from " + client.Client.Client.RemoteEndPoint.ToString());
        //                PoChatServerMessageManager.Instance.Add(msg);
        //                _clientsConnected.TryAdd(client.Id, client);
        //                var thread = new Thread(() => ManageConnection(client));
        //                thread.IsBackground = true;
        //                thread.Start();
        //            }
        //            else
        //            {
        //                //TODO megszűntetni!
        //                Thread.Sleep(500);
        //            }
        //        }
        //        //listener.Stop();
        //        listener.Server.Close();
        //        _active = false;
        //    }
        //    catch (Exception e)
        //    {
        //        PoLogger.LogException(_logSource, e);
        //    }
        //}
    }
}
