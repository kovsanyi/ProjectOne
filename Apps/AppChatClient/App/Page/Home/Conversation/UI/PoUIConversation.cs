using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public partial class PoUIConversation : PoUILayout
    {
        private PoUILayout _messageBubbleContainer;
        private readonly string _otherParty;

        public PoUIConversation(string otherParty) : base()
        {
            _otherParty = otherParty;
            AddClass("conversation-form");
            AddMessageBubbleContainer();
            //AddMessageInput();
        }

        private void AddMessageBubbleContainer()
        {
            _messageBubbleContainer = new PoUILayout();
            _messageBubbleContainer.AddClass("message-container");
            Add(_messageBubbleContainer);
        }

        private void AddMessageInput(string fromUsername, string toUsername)
        {
            var mi = new PoUIMessageInput(fromUsername, toUsername);
            mi.AddClass("message-input");
            Add(mi);
        }

        private bool _initialized;
        public override void Index2(PoHttpRequest request)
        {
            if (_initialized) return;
            _initialized = true;
            var username = request.User.Username;
            var conversation = PoChatConversationManager.Instance.FindOrCreateConversation(username, _otherParty);
            var messagesOrdered = conversation.GetMessagesOrdered();
            AddChatMessages(messagesOrdered);
            conversation.OnMessageAdded += Conversation_OnMessageAdded;
            AddMessageInput(username, _otherParty);
            Refresh();
        }

        private void AddChatMessages(List<PoChatMessage> messagesOrdered)
        {
            foreach (var message in messagesOrdered)
            {
                AddChatMessage(message);
            }
        }

        private void AddChatMessage(PoChatMessage message)
        {
            PoUIConversationBubble bubble;
            if (message.To == _otherParty)
                bubble = new PoUIConversationBubble(message.Content, PoUIConversationBubbleType.Friend);
            else
                bubble = new PoUIConversationBubble(message.Content, PoUIConversationBubbleType.Mine);
            _messageBubbleContainer.Add(bubble);
        }

        private void Conversation_OnMessageAdded(object sender, PoChatMessage e)
        {
            AddChatMessage(e);
        }
    }
}
