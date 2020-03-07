using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne
{
    partial class PoChatServer
    {
        private Task _send;

        private void SendMessage(PoConnectedClient client)
        {
            var msg = client.Data.ToString();
            if (_send == null || _send.IsCompleted)
            {
                _send = Task.Factory.StartNew(() => SendMessage(msg, client.Id));
            }
            else
            {
                _send.ContinueWith(ca => SendMessage(msg, client.Id));
            }
        }

        private void SendMessage(string msg, int clientId)
        {
            var buffer = Encoding.UTF8.GetBytes(msg);
            foreach (var clientById in _clientsConnected)
            {
                if (clientById.Key == clientId) continue;
                try
                {
                    clientById.Value.Stream.BeginWrite(buffer, 0, buffer.Length, Write, clientById.Value);
                }
                catch (Exception e)
                {
                    PoLogger.LogException(_logSource, e, $"Error while writing client data {clientById.Value.ToString()}.");
                }
            }
        }

        private void Write(IAsyncResult ar)
        {
            if (!(ar.AsyncState is PoConnectedClient client)) return;
            if (!client.IsAlive())
            {
                PoLogger.Log(_logSource, PoLogType.Warn, $"Cannot send data to client {client.ToString()}. Client disconnected.");
                return;
            }

            try
            {
                client.Stream.EndWrite(ar);
            }
            catch (Exception e)
            {
                PoLogger.LogException(_logSource, e, $"Cannot finish writing client data {client.ToString()}.");
            }
        }
    }
}
