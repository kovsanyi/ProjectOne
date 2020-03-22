using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoUIMessageInput : PoUILayout
    {
        private PoUIButton _sendButton;
        private PoUITextArea _messageInput;

        public PoUIMessageInput() : base(PoOrientationType.Horizontal)
        {
            AddTextArea();
            AddSendBtn();
        }

        private void AddTextArea()
        {
            _messageInput = new PoUITextArea();
            _messageInput.Style.SetStyle("width", "100%");
            _messageInput.Style.SetStyle("none", "resize");

            Add(_messageInput);
        }

        private void AddSendBtn()
        {
            _sendButton = new PoUIButton();
            _sendButton.Value = "Send";
            _sendButton.Script.InitScript(PoUIEventType.OnClick);
            _sendButton.Script.OnClick += OnSendButtonClicked;

            Add(_sendButton);
        }

        protected virtual void OnSendButtonClicked(object sender, PoHttpRequest req)
        {
            var msg = new PoChatServerMessage("guest@localhost", "guest@localhost", _messageInput.Value);
            PoChatServerMessageManager.Instance.Add(msg);
        }
    }
}
