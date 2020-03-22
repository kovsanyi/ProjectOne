using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectOne
{
    public class PoChatConversation : PoManagedItem
    {
        private static readonly object Sync = new object();
        public readonly string Party1;
        public readonly string Party2;
        public event EventHandler<PoChatMessage> OnMessageAdded;
        private readonly List<PoChatMessage> _messages = new List<PoChatMessage>();

        public PoChatConversation(string party1, string party2)
        {
            Party1 = party1;
            Party2 = party2;
        }

        public void Add(PoChatMessage message)
        {
            lock (Sync)
            {
                if ((message.From != Party1 || message.To != Party2) &&
                    (message.From != Party2 || message.To != Party1)) return;
                _messages.Add(message);
                OnMessageAdded?.Invoke(this, message);
            }
        }

        public List<PoChatMessage> GetMessagesOrdered()
        {
            lock (Sync)
            {
                var ret = _messages.ToList();
                return ret;
            }
        }
    }
}
