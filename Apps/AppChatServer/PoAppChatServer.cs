using System;
using System.Net;

namespace ProjectOne
{
    public partial class PoAppChatServer : IPoApp
    {
        public void CallOnOpened() { }

        public void CallOnClosed() { }

        public void CallOnStarted()
        {
            var port = 2107;
            var server = new PoChatServer(port);
            //DEBUG
            server.OnUserConnected += Server_OnUserConnected;
            server.OnChatMessageReceived += Server_OnNewMessage; ;

            server.Start();
        }

        private void Server_OnNewMessage(PoChatMessage message)
        {
            var msg = new PoChatServerMessage(string.Empty, string.Empty,
                $"Message received. From: {message.From}. To: {message.To}. Content: {message.Content}");
            PoChatServerMessageManager.Instance.Add(msg);
        }

        private void Server_OnUserConnected(string user)
        {
            var msg = new PoChatServerMessage(string.Empty, string.Empty, $"User connected: {user}");
            PoChatServerMessageManager.Instance.Add(msg);
        }

        public void CallOnStopped()
        {
            //PoChatServer.Instance.Stop();
        }
    }
}
