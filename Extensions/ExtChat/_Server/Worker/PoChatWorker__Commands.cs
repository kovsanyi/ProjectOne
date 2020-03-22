using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoChatWorker
    {
        private void CallOnLoginCommandReceived(PoNetworkMessage message)
        {
            if (!message.TryGetContent(out PoLoginRequest loginRequest)) return;
            Username = loginRequest.Username;
            var loginSuccess = new PoLoginSuccess();
            loginSuccess.UsersByStatus = _chatServer.GetConnectedUsers();
            SendAsync(PoNetworkMessageCommands.LoginSuccess, loginSuccess);
            _chatServer.Broadcast(PoNetworkMessageCommands.UserConnect, this, Username);
        }

        private void CallOnChatMessageCommandReceived(PoNetworkMessage message)
        {
            if (!message.TryGetContent(out PoChatMessage chatMessage)) return;
            _chatServer.SendMessage(chatMessage, Username);
        }

        private void CallOnLogoutCommandReceived(PoNetworkMessage message)
        {
            Terminate();
        }
    }
}
