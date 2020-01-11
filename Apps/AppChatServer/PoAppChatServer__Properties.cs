using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoAppChatServer
    {
        public string Name { get { return "Chat Server"; } }

        public string Description { get { return string.Empty; } }

        public string Icon { get { return PoIcon_ChatServer.DektopIcon; } }

        public string AppPrefix { get { return "ChatServer"; } }

        public string ToolTipMessage { get { return "Provides real time communication between users."; } }
    }
}
