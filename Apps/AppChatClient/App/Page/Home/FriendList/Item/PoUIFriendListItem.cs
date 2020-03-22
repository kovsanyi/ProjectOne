using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public partial class PoUIFriendListItem : PoUILayout
    {
        public readonly string FriendName;
        private PoUIImage _connectedState;

        public PoUIFriendListItem(string friendName, PoConnectedStatus connectedState) : base(PoOrientationType.Horizontal)
        {
            AddClass("friend-list-item");
            FriendName = friendName;
            InitComponents();
            SetStateIndicator(connectedState);
        }

        public void SetStateIndicator(PoConnectedStatus connectedState)
        {
            if (_connectedState == null || _connectedState.IsDisposed) return;
            switch (connectedState)
            {
                case PoConnectedStatus.Online:
                    _connectedState.Model.Source = CreateResourceStr(PoIcon_ChatClient.ConnectedStateOnline);
                    break;
                default:
                    _connectedState.Model.Source = CreateResourceStr(PoIcon_ChatClient.ConnectedStateOffline);
                    break;
            }
            _connectedState.Refresh();
            Refresh();
        }
    }
}
