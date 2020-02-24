using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ProjectOne
{
    partial class PoChatServer
    {
        private int _availableId = 0;
        private void Listener(IPAddress localAddr, int port)
        {
            var listener = new TcpListener(localAddr, port);
            listener.Start();
            while (_active)
            {
                if (listener.Pending())
                {
                    var client = new PoConnectedClient();
                    client.Id = _availableId++;
                    client.Client = listener.AcceptTcpClient();
                    client.Stream = client.Client.GetStream();
                    client.Buffer = new byte[client.Client.ReceiveBufferSize];
                    var thread = new Thread(() => Connection(client));
                    thread.IsBackground = true;
                }
                else
                {
                    Thread.Sleep(500);
                }
            }
        }

        private void Connection(PoConnectedClient client)
        {
            _clientsConnected.TryAdd(client.Id, client);
            if (client.Stream.CanRead && client.Stream.CanWrite)
            {
                while (client.Client.Connected)
                {
                    try
                    {
                        client.Stream.BeginRead(client.Buffer, 0, client.Buffer.Length, Read, client);
                        client.Handle.WaitOne();
                    }
                    catch (Exception e) { }
                }
            }
            else { }
            client.Client.Close();
            _clientsConnected.TryRemove(client.Id, out var removedClient);
        }
    }
}
