using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ProjectOne
{
    public class PoUIChatClientPage_Settings : PoUILayout
    {
        private PoUITextBox _inputServerAddress;
        private PoUIButton _btnConnect;

        public PoUIChatClientPage_Settings()
        {
            Add(CreateServerAddrInput());
        }

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
                //PoAppChatClient.ChatClient.Disconnect();
                PoAppChatClient.ChatClient = null;
                _btnConnect.Value = "Connect";
                _btnConnect.Refresh();
                return;
            }
            PoAppChatClient.ChatClient = new PoChatClient(IPAddress.Loopback, 2107);
            //PoAppChatClient.ChatClient.
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
