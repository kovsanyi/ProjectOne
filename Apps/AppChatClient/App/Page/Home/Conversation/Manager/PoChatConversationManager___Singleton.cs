using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoChatConversationManager
    {
        private static readonly Lazy<PoChatConversationManager> Lazy
           = new Lazy<PoChatConversationManager>(() => new PoChatConversationManager());

        public static PoChatConversationManager Instance => Lazy.Value;
    }
}
