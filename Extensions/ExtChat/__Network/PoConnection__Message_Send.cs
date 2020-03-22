using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace ProjectOne
{
    partial class PoConnection
    {
        private readonly object _sendSync = new object();

        public void SendAsync(PoNetworkMessageCommands command, object content)
        {
            PoBackgroundJob.Enqueue(() => Send(command, content), GetType().Name + "/" + "SendAsync");
        }

        public void Send(PoNetworkMessageCommands command, object content = null)
        {
            try
            {
                var message = new PoNetworkMessage();
                message.Command = command;
                message.Content = JsonSerializer.Serialize(content);

                var msgSerialized = JsonSerializer.Serialize(message);
                var msgBytes = Encoding.UTF8.GetBytes(msgSerialized);
                lock (_sendSync)
                {
                    _stream.BeginWrite(msgBytes, 0, msgBytes.Length, WriteCallback, null);
                }
            }
            catch (ObjectDisposedException) { PoLogger.Log(PoLogSource.Default, PoLogType.Warn, "Sending cancelled. Client connection closed."); }
            catch (Exception e) { PoLogger.LogException(PoLogSource.Default, e, "Error occured while sending network message."); }
        }

        private void WriteCallback(IAsyncResult ar)
        {
            try
            {
                //TODO client received impl.
                _stream.EndWrite(ar);
            }
            catch (ObjectDisposedException) { PoLogger.Log(PoLogSource.Default, PoLogType.Warn, "Listening cancelled. Client connection closed."); }
            catch (Exception e) { PoLogger.LogException(PoLogSource.Default, e, "Error occured while sending network message. WriteCallback."); }
        }
    }
}
