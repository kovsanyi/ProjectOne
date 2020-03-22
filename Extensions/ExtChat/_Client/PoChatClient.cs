using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ProjectOne
{
    public partial class PoChatClient : PoConnection
    {
        public PoChatClient(IPAddress serverAddress, int serverPort) : base()
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(serverAddress, serverPort);
            InitCommands();
            Start(socket);
        }

        public void SendLoginRequest(string username, string password)
        {
            var loginRequest = new PoLoginRequest();
            loginRequest.Username = username;
            loginRequest.Password = password;
            SendAsync(PoNetworkMessageCommands.Login, loginRequest);
        }

        public void SendMessage(PoChatMessage message)
        {
            SendAsync(PoNetworkMessageCommands.ChatMessage, message);
        }

        private void InitCommands()
        {
            AddCommand(PoNetworkMessageCommands.LoginSuccess, CallOnLoginSuccessCommandReceived);
            AddCommand(PoNetworkMessageCommands.LoginFail, CallOnLoginFailCommandReceived);
            AddCommand(PoNetworkMessageCommands.UserConnect, CallOnUserConnectCommandReceived);
            AddCommand(PoNetworkMessageCommands.UserDisconnect, CallOnUserDisconnectCommandReceived);
            AddCommand(PoNetworkMessageCommands.ChatMessage, CallOnChatMessageCommandReceived);
        }
    }
}
