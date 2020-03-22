using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoChatServer
    {
        //private void ManageConnection(PoConnectedClient client)
        //{
        //    if (!client.Stream.CanRead && !client.Stream.CanWrite)
        //    {
        //        PoLogger.Log(_logSource, PoLogType.Error, $"Cannot read stream of client {client.ToString()}. Client will be disconnected.");
        //        DisconnectClient(client);
        //    }
        //    while (client.IsAlive())
        //    {
        //        try
        //        {
        //            client.Stream.BeginRead(client.Buffer, 0, client.Buffer.Length, Read, client);
        //            client.Handle.WaitOne();
        //        }
        //        catch (Exception e)
        //        {
        //            PoLogger.LogException(_logSource, e, $"Error while reading client data {client.ToString()}.");
        //        }
        //    }
        //    DisconnectClient(client);
        //}

        //private void DisconnectClient(PoConnectedClient client)
        //{
        //    client.Disconnect();
        //    _clientsConnected.TryRemove(client.Id, out var tmp);

        //    var msgVal = $"Client {client.ToString()} connection closed.";
        //    PoLogger.Log(_logSource, PoLogType.Info, msgVal);
        //    var msg = new PoChatServerMessage(string.Empty, string.Empty, msgVal);
        //    PoChatServerMessageManager.Instance.Add(msg);
        //}
    }
}
