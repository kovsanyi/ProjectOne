using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne
{
    partial class PoChatServer
    {
        private void SendMessage(PoConnectedClient client)
        {
            var msg = client.Data.ToString();
            if (_send == null || _send.IsCompleted)
            {
                _send = Task.Factory.StartNew(() => Send(msg, client.Id));
            }
            else
            {
                _send.ContinueWith(ca => Send(msg, client.Id));
            }
        }

        private void Send(string msg, int clientId)
        {
            var buffer = Encoding.UTF8.GetBytes(msg);
            foreach (var clientById in _clientsConnected)
            {
                if (clientById.Key == clientId) continue;
                try
                {
                    clientById.Value.Stream.BeginWrite(buffer, 0, buffer.Length, Write, clientById.Value);
                }
                catch (Exception e) { }
            }
        }

        private void Write(IAsyncResult ar)
        {
            if (!(ar is PoConnectedClient client)) return;
            if (!client.Client.Connected) return;
            try
            {
                client.Stream.EndWrite(ar);
            }
            catch (Exception e) { }
        }
    }
}
