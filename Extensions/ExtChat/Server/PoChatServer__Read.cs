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
            if (!client.Client.Connected) return;
            int bytesRead = 0;
            try
            {
                bytesRead = client.Stream.EndRead(result);
            }
            catch (Exception e) { }

            if (bytesRead == 0)
            {
                client.Client.Close();
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
            catch (Exception e) { }

            if (dataAvailable)
            {
                try
                {
                    client.Stream.BeginRead(client.Buffer, 0, client.Buffer.Length, Read, client);
                }
                catch (Exception e) { }
                finally
                {
                    client.Handle.Set();
                }
            }
            else
            {
                SendMessage(client);
                client.Data.Clear();
                client.Handle.Set();
            }
        }
    }
}
