using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoChatClient
    {
        private void Read()
        {
            if (!_server.Stream.CanRead && !_server.Stream.CanWrite)
            {
                PoLogger.Log(_logSource, PoLogType.Warn, $"Cannot read server data {_server.ToString()}. Disconnect from server.");
                Disconnect();
                return;
            }
            try
            {
                _server.Stream.BeginRead(_server.Buffer, 0, _server.Buffer.Length, Read, null);
                _server.Handle.WaitOne();
            }
            catch (Exception e) { PoLogger.LogException(_logSource, e); }
        }

        private void Read(IAsyncResult ar)
        {
            int bytes = 0;
            if (_server.IsAlive())
            {
                try
                {
                    bytes = _server.Stream.EndRead(ar);
                }
                catch (Exception e) { PoLogger.LogException(_logSource, e); }
            }

            if (bytes == 0)
            {
                Disconnect();
                _server.Handle.Set();
                return;
            }
            _server.Data.AppendLine(Encoding.UTF8.GetString(_server.Buffer, 0, bytes));
            CheckForAvailableData();
        }

        void CheckForAvailableData()
        {
            bool dataAvailable = false;
            try
            {
                dataAvailable = _server.Stream.DataAvailable;
            }
            catch (Exception e) { }

            if (!dataAvailable)
            {
                _server.Data.Clear();
                _server.Handle.Set();
            }
            try
            {
                _server.Stream.BeginRead(_server.Buffer, 0, _server.Buffer.Length, Read, null);
            }
            catch (Exception e) { PoLogger.LogException(_logSource, e); }
            finally
            {
                _server.Handle.Set();
            }
        }
    }
}
