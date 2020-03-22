using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoChatMessage
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }

        public PoChatMessage(string from, string to, string content, DateTime createdDate) : this()
        {
            From = from;
            To = to;
            Content = content;
            CreatedDate = createdDate;
        }

        public PoChatMessage() : base() { }
    }
}
