using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoChatServer
    {
        private bool _active;

        public bool Start()
        {
            if (IsRunning())
            {
                PoLogger.Log(_logSource, PoLogType.Error, $"Cannot start chat server. It is already running on {_ipAddress.MapToIPv4().ToString()}:{_port}.");
                return false;
            }
            if (!IsPortValid(_port))
            {
                PoLogger.Log(_logSource, PoLogType.Error, $"Cannot start chat server. Port out of range: {_port}.");
                return false;
            }
            if (_ipAddress == null)
            {
                PoLogger.Log(_logSource, PoLogType.Error, $"Cannot start chat server. IP address must be set!");
                return false;
            }

            PoLogger.Log(_logSource, PoLogType.Info, $"Starting chat server at {_ipAddress.MapToIPv4().ToString()}:{_port}");
            StartListenerAsync();
            return true;
        }

        private bool IsRunning()
        {
            if (_active) return true;
            //var ret = _listenerThread != null && _listenerThread.IsAlive;
            return false;
        }

        private bool IsPortValid(int port)
        {
            var ret = port >= 0 && port <= 65535;
            return ret;
        }
    }
}
