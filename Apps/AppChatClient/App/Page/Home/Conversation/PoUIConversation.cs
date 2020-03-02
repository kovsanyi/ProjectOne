﻿using System;
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
            PoChatMessageManager.Instance.OnItemAdded += OnMessageArrived;
        }

        private void OnMessageArrived(object sender, PoChatMessage e)
        {
            var msg = new PoUIConversationBubble(e.Message, PoUIConversationBubbleType.Mine);
            _messageBubbleContainer.Add(msg);
        }

        private void AddMessageInput()
        {
            var mi = new PoUIMessageInput();

            Add(mi);
        }

        private void AddMessageBubbleContainer()
        {
            var msg1 = new PoUIConversationBubble(GetSample(), PoUIConversationBubbleType.Friend);
            var msg2 = new PoUIConversationBubble(GetSample(), PoUIConversationBubbleType.Mine);
            var msg3 = new PoUIConversationBubble(GetSample(), PoUIConversationBubbleType.Friend);
            var msg4 = new PoUIConversationBubble(GetSample(), PoUIConversationBubbleType.Friend);
            var msg5 = new PoUIConversationBubble(GetSample(), PoUIConversationBubbleType.Mine);
            var msg6 = new PoUIConversationBubble(GetSample(), PoUIConversationBubbleType.Friend);

            _messageBubbleContainer = new PoUILayout();
            _messageBubbleContainer.Add(msg1);
            _messageBubbleContainer.Add(msg2);
            _messageBubbleContainer.Add(msg3);
            _messageBubbleContainer.Add(msg4);
            _messageBubbleContainer.Add(msg5);
            _messageBubbleContainer.Add(msg6);

            Add(_messageBubbleContainer);
        }

        string GetSample()
        {
            return "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam tempus libero nunc, " +
                   "ut congue lorem finibus vel. Curabitur sed luctus purus. Sed feugiat eros id elementum " +
                   "porta. Proin fermentum efficitur maximus. Nullam vestibulum sem tellus. Donec fringilla " +
                   "lacinia euismod. Etiam nunc metus, consectetur ut pulvinar in, consequat ac erat. Aliquam " +
                   "hendrerit dictum molestie.";
        }
    }
}
