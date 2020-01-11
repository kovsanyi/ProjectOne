using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectOne
{
    partial class PoServerRoot
    {
        public void Stop()
        {
            try
            {
                if (_listener == null) return;
                if (!_listener.IsListening) return;
                PoLogger.Log(PoLogSource.Default, PoLogType.Info, $"Stopping server: {_listener.Prefixes.FirstOrDefault()}");
                _listener.Stop();
                _listener = null;
            }
            catch (Exception e)
            {
                PoLogger.Log(PoLogSource.Default, PoLogType.Error, $"Error while stopping server at {_listener.Prefixes.FirstOrDefault()}. Exception: {e.Message}");
            }
        }
    }
}
