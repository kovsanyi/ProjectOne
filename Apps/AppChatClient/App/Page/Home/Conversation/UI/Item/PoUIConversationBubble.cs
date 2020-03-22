using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoUIConversationBubble : PoUILayout
    {
        public PoUIConversationBubble(string message, PoUIConversationBubbleType bubbleType) : this()
        {
            var span = new PoUISpan();
            span.Value = message;
            Add(span);

            switch (bubbleType)
            {
                case PoUIConversationBubbleType.Mine:
                    AddClass("bubble-mine");
                    break;
                default:
                    AddClass("bubble-friend");
                    break;
            }
        }

        public PoUIConversationBubble() : base()
        {
            AddClass("conversation-bubble");
        }
    }
}
