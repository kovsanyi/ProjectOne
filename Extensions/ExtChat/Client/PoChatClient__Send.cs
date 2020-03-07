using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoChatClient
    {
        public void Send(string msg)
        {
            try
            {
                var buffer = Encoding.UTF8.GetBytes(msg);
                _server.Stream.BeginWrite(buffer, 0, buffer.Length, Write, null);
            }
            catch (Exception e) { PoLogger.LogException(_logSource, e); }
        }

        private void Write(IAsyncResult ar)
        {
            if (!_server.IsAlive())
            {
                PoLogger.Log(_logSource, PoLogType.Warn, "Cannot send message. Disconnected from server.");
                return;
            }
            try
            {
                _server.Stream.EndWrite(ar);
            }
            catch (Exception e) { PoLogger.LogException(_logSource, e, "Error while sending message."); }
        }
    }
}
