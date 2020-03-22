using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoChatClient
    {
        public delegate void CallOnLoginSucceeded(Dictionary<string, PoConnectedStatus> usersByStatus);
        public event CallOnLoginSucceeded OnLoginSucceeded;

        public delegate void CallOnLoginFailed();
        public event CallOnLoginFailed OnLoginFailed;

        public delegate void CallOnUserConnected(string username, string domain);
        public event CallOnUserConnected OnUserConnected;

        public delegate void CallOnUserDisconnected(string username, string domain);
        public event CallOnUserDisconnected OnUserDisconnected;

        public delegate void CallOnMessageReceived(PoChatMessage message);
        public event CallOnMessageReceived OnMessageReceived;

        //public delegate void CallOnConnectionConnect();
        //public event CallOnConnectionConnect OnConnectionConnect;

        //public delegate void CallOnSetUsername(string username);
        //public event CallOnSetUsername OnSetUsername;

        //public delegate void CallOnUsernameTaken();
        //public event CallOnUsernameTaken OnUsernameTaken;

        //public delegate void CallOnUsernameChanged(string oldUsername, string changedUsername);
        //public event CallOnUsernameChanged OnUsernameChanged;

        //public delegate void CallOnUserKicked(string username);
        //public event CallOnUserKicked OnUserKicked;
    }
}
