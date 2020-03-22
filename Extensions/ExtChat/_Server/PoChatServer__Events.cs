using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoChatServer
    {
        public delegate void CallOnNewMessage(PoChatMessage message);
        public event CallOnNewMessage OnChatMessageReceived;

        public delegate void CallOnUserConnected(string username);
        public event CallOnUserConnected OnUserConnected;

        public delegate void CallOnUserDisconnected(string username);
        public event CallOnUserDisconnected OnUserDisconnected;

        public delegate void CallOnServerStarted();
        public event CallOnServerStarted OnServerStarted;

        public delegate void CallOnServerStopped();
        public event CallOnServerStopped OnServerStopped;
    }
}
