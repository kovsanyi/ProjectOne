using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoUIChatClientPage_Home : PoUILayout
    {
        PoUIConversation _conversation;

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
            fl.OnFriendSelected += FriendList_OnFriendSelected;
            Add(fl);

            _conversation = new PoUIConversation();
            Add(_conversation);
        }

        private void FriendList_OnFriendSelected(object sender, string friendUsername)
        {
            if (_conversation != null)
            {
                Remove(_conversation);
                _conversation.Dispose();
            }
            _conversation = new PoUIConversation(friendUsername);
            Add(_conversation);
        }

        public override void Index2(PoHttpRequest request)
        {
            //PoAppChatClient.InitChatClientIfNotInitialized(request.User.Username, request.User.Domain, request.User.Password);
        }
    }
}
