using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public partial class PoChatConversationManager : PoItemManager<PoChatConversation>
    {
        //private static object Sync = new object();

        public void Start()
        {
            PoAppChatClient.ChatClient.OnMessageReceived += ChatClient_OnMessageReceived;
        }

        public PoChatConversation FindOrCreateConversation(string party1, string party2)
        {
            var items = GetItems();
            foreach (var item in items)
            {
                if ((item.Party1 != party1 || item.Party2 != party2) && (item.Party1 != party2 || item.Party2 != party1)) continue;
                return item;
            }
            var conv = new PoChatConversation(party1, party2);
            Add(conv);
            return conv;
        }

        private void ChatClient_OnMessageReceived(PoChatMessage message)
        {
            AddMessage(message);
        }

        public void AddMessage(PoChatMessage message)
        {
            var conv = FindOrCreateConversation(message.From, message.To);
            conv.Add(message);
        }
    }
}
