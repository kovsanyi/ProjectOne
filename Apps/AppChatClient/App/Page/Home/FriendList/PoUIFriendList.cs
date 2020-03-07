using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ProjectOne
{
    public class PoUIFriendList : PoUILayout
    {
        public PoUIFriendList() : base()
        {
            Style.SetStyle("padding", "10px");
            InitComponents();
        }

        private void InitComponents()
        {
            var usr1 = new PoUIFriendListItem("PO User Lucy", PoConnectedState.Online);
            var usr2 = new PoUIFriendListItem("PO User Emily", PoConnectedState.Online);
            var usr3 = new PoUIFriendListItem("PO User Jack", PoConnectedState.Offline);
            Add(usr1);
            Add(usr2);
            Add(usr3);
            Add(CreateServerAddrInput());
        }

        private PoUITextBox _inputServerAddress;
        private PoUIButton _btnConnect;
        private PoUIComponent CreateServerAddrInput()
        {
            _inputServerAddress = new PoUITextBox();
            _inputServerAddress.Model.Value = "127.0.0.1:2107";

            _btnConnect = new PoUIButton();
            _btnConnect.Value = "Connect";
            _btnConnect.Script.InitScript(PoUIEventType.OnClick);
            _btnConnect.Script.OnClick += Script_OnClick;

            var layout = new PoUILayout(PoOrientationType.Horizontal);
            layout.Add(_inputServerAddress);
            layout.Add(_btnConnect);
            return layout;
        }

        private void Script_OnClick(object sender, PoHttpRequest e)
        {
            if (_inputServerAddress == null || _inputServerAddress.IsDisposed) return;
            if (PoAppChatClient.ChatClient != null)
            {
                PoAppChatClient.ChatClient.Disconnect();
                PoAppChatClient.ChatClient = null;
                _btnConnect.Value = "Connect";
                _btnConnect.Refresh();
                return;
            }
            PoAppChatClient.ChatClient = new PoChatClient(IPAddress.Loopback, 2107);
            PoAppChatClient.ChatClient.Connect();
            _btnConnect.Value = "Disconnect";
            _btnConnect.Refresh();
        }

        protected override void DisposeContent()
        {
            if (_inputServerAddress != null)
            {
                _inputServerAddress.Dispose();
                _inputServerAddress = null;
            }
        }
    }
}
