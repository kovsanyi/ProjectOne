using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoUIMessageInput : PoUILayout
    {
        private readonly string _fromUsername;
        private readonly string _toUsername;
        private PoUITextArea _messageInput;
        private PoUIButton _sendButton;

        public PoUIMessageInput(string fromUsername, string toUsername) : base()
        {
            _fromUsername = fromUsername;
            _toUsername = toUsername;
            AddTextArea();
            AddSendBtn();
        }

        private void AddTextArea()
        {
            _messageInput = new PoUITextArea();
            _messageInput.Style.SetStyle("width", "100%");
            _messageInput.Style.SetStyle("resize", "none");

            Add(_messageInput);
        }

        private void AddSendBtn()
        {
            var btnContent = new PoUISpan();
            btnContent.Value = "Send";

            _sendButton = new PoUIButton();
            _sendButton.AddClass("chat-send-btn");
            _sendButton.Style = PoButtonStyle.Info;
            _sendButton.Value = btnContent.ToHtml();
            _sendButton.Script.InitScript(PoUIEventType.OnClick);
            _sendButton.Script.OnClick += OnSendButtonClicked;

            Add(_sendButton);
        }

        protected virtual void OnSendButtonClicked(object sender, PoHttpRequest req)
        {
            if (PoAppChatClient.ChatClient == null) return;
            var msg = new PoChatMessage(_fromUsername, _toUsername, _messageInput.Value, DateTime.Now);
            PoAppChatClient.ChatClient.SendMessage(msg);
        }
    }
}
