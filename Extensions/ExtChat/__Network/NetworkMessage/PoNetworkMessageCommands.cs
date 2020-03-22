using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public enum PoNetworkMessageCommands
    {
        Setup,
        Login,
        LoginSuccess,
        LoginFail,
        Logout,
        ChatMessage,
        Users,
        UserConnect,
        UserDisconnect
    }
}
