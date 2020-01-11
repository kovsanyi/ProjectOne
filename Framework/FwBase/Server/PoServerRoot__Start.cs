using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;

namespace ProjectOne
{
    partial class PoServerRoot
    {
        public void Start()
        {
            try
            {
                if (_listener == null) return;
                if (_listener.IsListening) return;
                PoLogger.Log(PoLogSource.Default, PoLogType.Info, $"Starting server: {_listener.Prefixes.FirstOrDefault()}");
                _listener.Start();
                PoBackgroundJob.Enqueue(() => listenerThread());
            }
            catch (Exception e)
            {
                PoLogger.Log(PoLogSource.Default, PoLogType.Error, $"Error while starting server: {_listener.Prefixes.FirstOrDefault()}. Exception: {e.Message}");
            }
        }

        void listenerThread()
        {
            while (_listener.IsListening)
            {
                try
                {
                    while (_listener.IsListening)
                    {
                        var context = _listener.GetContext();
                        ThreadPool.QueueUserWorkItem(handleRequest, context);
                    }
                }
                catch (Exception e)
                {
                    PoLogger.Log(PoLogSource.Default, PoLogType.Error, $"Client disconnected or other error. Exception: {e.Message}");
                }
            }
        }
    }
}
