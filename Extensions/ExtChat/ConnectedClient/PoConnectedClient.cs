using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ProjectOne
{
    public class PoConnectedClient
    {
        public readonly DateTime ConnectedDate;
        public int Id;
        public TcpClient Client;
        public NetworkStream Stream;
        public byte[] Buffer;
        public StringBuilder Data;
        public EventWaitHandle Handle;

        public PoConnectedClient(int id, TcpClient client) : this()
        {
            Id = id;
            Client = client;
            Stream = client.GetStream();
            Buffer = new byte[client.Client.ReceiveBufferSize];
        }

        public PoConnectedClient()
        {
            ConnectedDate = DateTime.Now;
            Data = new StringBuilder();
            Handle = new EventWaitHandle(false, EventResetMode.AutoReset);
        }

        public bool IsAlive()
        {
            return Client.Connected;
        }

        public void Disconnect()
        {
            Client.Close();
        }

        public override string ToString()
        {
            return $"{nameof(PoConnectedClient)}_{Id}";
        }
    }
}
