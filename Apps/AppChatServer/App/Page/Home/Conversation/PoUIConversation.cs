using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoUIConversation : PoUILayout
    {
        private PoUILayout _messageBubbleContainer;

        public PoUIConversation() : base()
        {
            AddMessageBubbleContainer();
            AddMessageInput();
            PoChatServerMessageManager.Instance.OnItemAdded += OnMessageArrived;
        }

        private void OnMessageArrived(object sender, PoChatServerMessage e)
        {
            var msg = new PoUIConversationBubble(e.Message, PoUIConversationBubbleType.Mine);
            _messageBubbleContainer.Add(msg);
        }

        private void AddMessageInput()
        {
            var mi = new PoUIMessageInput();
            mi.AddClass("message-input");
            Add(mi);
        }

        private void AddMessageBubbleContainer()
        {
            _messageBubbleContainer = new PoUILayout();
            _messageBubbleContainer.AddClass("message-container");

            Add(_messageBubbleContainer);
        }
    }
}
