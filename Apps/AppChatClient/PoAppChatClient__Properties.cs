using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoAppChatClient
    {
        public string Name => "Chat Client";

        public string Description => string.Empty;

        public string Icon => PoIcon_ChatClient.DesktopIcon;

        public string AppPrefix => "ChatClient";

        public string ToolTipMessage => "Provides real time communication between users.";
    }
}
