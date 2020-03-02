using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoUIConversationBubble : PoUILayout
    {
        public override List<PoUIHeadElement> HeadElements()
        {
            var elements = base.HeadElements();
            elements.Add(new PoUIHeadElementCSS(CreateResourceStr("ChatBase.css")));
            return elements;
        }

        public PoUIConversationBubble(string message, PoUIConversationBubbleType bubbleType)
        {
            var span = new PoUISpan();
            span.Value = message;
            Add(span);

            switch (bubbleType)
            {
                case PoUIConversationBubbleType.Mine:
                    AddClass("BubbleMine");
                    break;
                default:
                    AddClass("BubbleFriend");
                    break;
            }
        }
    }
}
