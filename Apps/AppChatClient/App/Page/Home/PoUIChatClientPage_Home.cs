using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoUIChatClientPage_Home : PoUILayout
    {
        public PoUIChatClientPage_Home() : base(PoOrientationType.Horizontal)
        {
            var fl = new PoUIFriendList();
            var conv = new PoUIConversation();
            Add(fl);
            Add(conv);
        }
    }
}
