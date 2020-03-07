using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne
{
    partial class PoChatServer
    {
        private void Read(IAsyncResult result)
        {
            if (!(result.AsyncState is PoConnectedClient client)) return;
            if (!client.IsAlive())
            {
                PoLogger.Log(_logSource, PoLogType.Warn, $"Cannot read data of client {client.ToString()}. Client disconnected.");
                return;
            }

            int bytesRead = 0;
            try
            {
                bytesRead = client.Stream.EndRead(result);
            }
            catch (Exception e)
            {
                PoLogger.LogException(_logSource, e, $"Cannot finish reading client data {client.ToString()}.");
            }

            if (bytesRead == 0)
            {
                DisconnectClient(client);
                client.Handle.Set();
                return;
            }

            Read(client, bytesRead);
        }

        private void Read(PoConnectedClient client, int bytesRead)
        {
            var data = Encoding.UTF8.GetString(client.Buffer, 0, bytesRead);
            client.Data.AppendLine(data);

            bool dataAvailable = false;
            try
            {
                dataAvailable = client.Stream.DataAvailable;
            }
            catch (Exception e) { PoLogger.LogException(_logSource, e); }

            if (dataAvailable)
            {
                try
                {
                    client.Stream.BeginRead(client.Buffer, 0, client.Buffer.Length, Read, client);
                }
                catch (Exception e) { PoLogger.LogException(_logSource, e); }
                finally { client.Handle.Set(); }
            }
            else
            {
                //SendMessage(client);
                var msg = new PoChatServerMessage(string.Empty, string.Empty, client.Data.ToString());
                PoChatServerMessageManager.Instance.Add(msg);
                client.Data.Clear();
                client.Handle.Set();
            }
        }
    }
}
