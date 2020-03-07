using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public partial class PoUIFriendListItem : PoUILayout
    {
        public readonly string FriendName;
        private PoUIImage _connectedState;

        public PoUIFriendListItem(string friendName, PoConnectedState connectedState) : base(PoOrientationType.Horizontal)
        {
            FriendName = friendName;
            InitComponents();
            SetStateIndicator(connectedState);
        }

        public void SetStateIndicator(PoConnectedState connectedState)
        {
            if (_connectedState == null || _connectedState.IsDisposed) return;
            switch (connectedState)
            {
                case PoConnectedState.Online:
                    _connectedState.Model.Source = CreateResourceStr(PoIcon_ChatServer.ConnectedStateOnline);
                    break;
                default:
                    _connectedState.Model.Source = CreateResourceStr(PoIcon_ChatServer.ConnectedStateOffline);
                    break;
            }
            _connectedState.Refresh();
            Refresh();
        }
    }
}
