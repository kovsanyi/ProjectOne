using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoAppChatServer
    {
        public string Name => "Chat Server";

        public string Description => string.Empty;

        public string Icon => PoIcon_ChatServer.DesktopIcon;

        public string AppPrefix => "ChatServer";

        public string ToolTipMessage => "Provides real time communication between users.";
    }
}
