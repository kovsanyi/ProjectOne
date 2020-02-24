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
                byte[] buffer = Encoding.UTF8.GetBytes(msg);
                _server.Stream.BeginWrite(buffer, 0, buffer.Length, Write, null);
            }
            catch (Exception e) { }
        }

        private void Write(IAsyncResult ar)
        {
            if (_server.Client.Connected)
            {
                try
                {
                    _server.Stream.EndWrite(ar);
                }
                catch (Exception e) { }
            }
        }
    }
}
