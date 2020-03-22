using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoChatClientMessage : PoManagedItem
    {
        public readonly string From;
        public readonly string To;
        public readonly string Message;
        public readonly DateTime Sent;

        private DateTime _received;
        public DateTime Received => _received;

        public PoChatClientMessage(string from, string to, string message)
        {
            From = from;
            To = to;
            Message = message;
            Sent = DateTime.Now;
        }
    }
}
