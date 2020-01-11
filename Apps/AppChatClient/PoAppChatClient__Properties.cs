using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoAppChatClient
    {
        public string Name { get { return "Chat Client"; } }

        public string Description { get { return string.Empty; } }

        public string Icon { get { return PoIcon_ChatClient.DektopIcon; } }

        public string AppPrefix { get { return "ChatClient"; } }

        public string ToolTipMessage { get { return "Provides real time communication between users."; } }
    }
}
