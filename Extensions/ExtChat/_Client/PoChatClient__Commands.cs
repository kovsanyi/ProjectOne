using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoChatClient
    {
        public readonly ConcurrentDictionary<string, PoConnectedStatus> ConnectedUsers = new ConcurrentDictionary<string, PoConnectedStatus>();

        private void CallOnLoginSuccessCommandReceived(PoNetworkMessage message)
        {
            if (!message.TryGetContent(out PoLoginSuccess content)) return;
            foreach (var users in content.UsersByStatus)
                ConnectedUsers.TryAdd(users.Key, users.Value);
            OnLoginSucceeded?.Invoke(content.UsersByStatus);
        }

        private void CallOnLoginFailCommandReceived(PoNetworkMessage message)
        {
            OnLoginFailed?.Invoke();
        }

        private void CallOnUserConnectCommandReceived(PoNetworkMessage message)
        {
            if (!message.TryGetContent(out PoUserConnected content)) return;
            if (!ConnectedUsers.TryAdd(content.Username, PoConnectedStatus.Online))
                ConnectedUsers[content.Username] = PoConnectedStatus.Online;
            OnUserConnected?.Invoke(content.Username, content.Domain);
        }

        private void CallOnUserDisconnectCommandReceived(PoNetworkMessage message)
        {
            if (!message.TryGetContent(out PoUserDisconnected content)) return;
            if (!ConnectedUsers.TryAdd(content.Username, PoConnectedStatus.Offline))
                ConnectedUsers[content.Username] = PoConnectedStatus.Offline;
            OnUserDisconnected?.Invoke(content.Username, content.Domain);
        }

        private void CallOnChatMessageCommandReceived(PoNetworkMessage message)
        {
            if (!message.TryGetContent(out PoChatMessage chatMesssage)) return;
            OnMessageReceived?.Invoke(chatMesssage);
        }
    }
}
