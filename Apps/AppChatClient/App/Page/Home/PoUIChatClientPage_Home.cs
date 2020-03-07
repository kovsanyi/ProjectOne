using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoUIChatClientPage_Home : PoUILayout
    {
        public override List<PoUIHeadElement> HeadElements()
        {
            var headElements = base.HeadElements();
            headElements.Add(new PoUIHeadElementCSS(CreateResourceStr("PoChatClient.css")));
            return headElements;
        }

        public PoUIChatClientPage_Home() : base(PoOrientationType.Horizontal)
        {
            AddClass("chat-client-home");

            var fl = new PoUIFriendList();
            fl.AddClass("friend-list");
            Add(fl);

            var conv = new PoUIConversation();
            conv.AddClass("conversation-form");
            Add(conv);
        }
    }
}
