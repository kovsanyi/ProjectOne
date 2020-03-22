using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace ProjectOne
{
    public partial class PoChatWorker : PoConnection
    {
        private readonly PoChatServer _chatServer;
        public string Username;

        public PoChatWorker(string username, Socket socket, PoChatServer chatServer) : base()
        {
            Username = username;
            _chatServer = chatServer;
            InitCommands();
            //Start(socket);
        }

        private void InitCommands()
        {
            AddCommand(PoNetworkMessageCommands.Login, CallOnLoginCommandReceived);
            AddCommand(PoNetworkMessageCommands.Logout, CallOnLogoutCommandReceived);
            AddCommand(PoNetworkMessageCommands.ChatMessage, CallOnChatMessageCommandReceived);
        }

        public override void Terminate()
        {
            Send(PoNetworkMessageCommands.Logout);
            _chatServer.Broadcast(PoNetworkMessageCommands.UserDisconnect, this, Username);
            base.Terminate();
            _chatServer.Remove(this);
        }
    }
}
