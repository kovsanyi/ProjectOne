using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace ProjectOne
{
    partial class PoConnection
    {
        private readonly AutoResetEvent _messageProcessed = new AutoResetEvent(false);

        private void Listen()
        {
            try
            {
                while (!Stop)
                {
                    _stream.BeginRead(_buffer, 0, _buffer.Length, ReadCallback, null);
                    _messageProcessed.WaitOne();
                }
            }
            catch (ObjectDisposedException) { PoLogger.Log(PoLogSource.Default, PoLogType.Warn, "Listening cancelled. Client connection closed."); }
            catch (Exception e) { PoLogger.LogException(PoLogSource.Default, e, "Error occured while listening."); }
            finally { OnDisconnected?.Invoke(); }
        }

        private void ReadCallback(IAsyncResult ar)
        {
            try
            {
                var bytesReceived = _socket.EndReceive(ar);
                var messageSerialized = Encoding.UTF8.GetString(_buffer, 0, bytesReceived);
                var message = GetNetworkMessage(messageSerialized);
                ProcessMessageAsync(message);
                _messageProcessed.Set();
            }
            catch (ObjectDisposedException) { PoLogger.Log(PoLogSource.Default, PoLogType.Warn, "Reading cancelled. Client connection closed."); }
            catch (Exception e) { PoLogger.LogException(PoLogSource.Default, e, "Error occured while reading."); }
        }

        private PoNetworkMessage GetNetworkMessage(string message)
        {
            try
            {
                var obj = JsonSerializer.Deserialize<PoNetworkMessage>(message);
                return obj;
            }
            catch (Exception e)
            {
                PoLogger.LogException(PoLogSource.Default, e, "Cannot deserialize network message.");
                return null;
            }
        }

        private void ProcessMessageAsync(PoNetworkMessage message)
        {
            PoBackgroundJob.Enqueue(() => ProcessMessage(message), $"{GetType().Name}/ProcessMessageAsync");
        }

        private void ProcessMessage(PoNetworkMessage message)
        {
            if (!_actionsByCommand.TryGetValue(message.Command, out var method))
            {
                PoLogger.Log(PoLogSource.Default, PoLogType.Warn,
                    $"Client received a message with command {message.Command.ToString()} but it is unsupported.");
            }
            method?.Invoke(message);
        }
    }
}
