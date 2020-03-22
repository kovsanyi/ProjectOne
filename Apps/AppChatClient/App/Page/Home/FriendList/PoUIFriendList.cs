using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace ProjectOne
{
    public class PoUIFriendList : PoUILayout
    {
        private bool _initialized;

        public event EventHandler<string> OnFriendSelected;

        public PoUIFriendList() : base()
        {
            AddClass("friend-list");
            InitComponents();
        }

        private void InitComponents() { }

        public override void Index2(PoHttpRequest request)
        {
            if (_initialized) return;
            _initialized = true;
            PoAppChatClient.InitChatClientIfNotInitialized(request.User.Username, request.User.Domain, request.User.Password);
            PoChatConversationManager.Instance.Start();
            PoAppChatClient.ChatClient.OnUserConnected += ChatClient_OnUserConnected;
            PoAppChatClient.ChatClient.OnUserDisconnected += ChatClient_OnUserDisconnected;
            InitFriendList(PoAppChatClient.ChatClient.ConnectedUsers.ToDictionary(x => x.Key, x => x.Value));
            PoAppChatClient.ChatClient.SendLoginRequest(request.User.Username, request.User.Password);
        }

        private void InitFriendList(Dictionary<string, PoConnectedStatus> usersByStatus)
        {
            foreach (var userByStatus in usersByStatus)
            {
                AddFriendListItem(userByStatus.Key, userByStatus.Value);
            }
        }

        private void ChatClient_OnUserConnected(string username, string domain)
        {
            foreach (var item in this)
            {
                if (!(item is PoUIFriendListItem friendListItem)) continue;
                if (friendListItem.FriendName != username) continue;
                friendListItem.SetStateIndicator(PoConnectedStatus.Online);
                return;
            }
            AddFriendListItem(username, PoConnectedStatus.Online);
        }

        private void ChatClient_OnUserDisconnected(string username, string domain)
        {
            foreach (var item in this)
            {
                if (!(item is PoUIFriendListItem friendListItem)) continue;
                if (friendListItem.FriendName != username) continue;
                friendListItem.SetStateIndicator(PoConnectedStatus.Offline);
                return;
            }
            AddFriendListItem(username, PoConnectedStatus.Offline);
        }

        private void AddFriendListItem(string username, PoConnectedStatus connectedStatus)
        {
            var item = new PoUIFriendListItem(username, PoConnectedStatus.Offline);
            item.Script.InitScript(PoUIEventType.OnClick);
            item.Script.OnClick += FriendListItem_OnClick;
            Add(item);
        }

        private void FriendListItem_OnClick(object sender, PoHttpRequest e)
        {
            if (!(sender is PoUIFriendListItem item)) return;
            OnFriendSelected?.Invoke(this, item.FriendName);
        }
    }
}
