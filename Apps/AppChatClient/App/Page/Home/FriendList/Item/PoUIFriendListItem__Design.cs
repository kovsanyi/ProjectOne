using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoUIFriendListItem
    {
        private void InitComponents()
        {
            InitStateIndicator();
            AddUserIcon();
            AddUsername();
        }

        private void InitStateIndicator()
        {
            _connectedState = new PoUIImage();
            _connectedState.Model.Width = "20px";
            _connectedState.Model.Source = CreateResourceStr(PoIcon_ChatClient.ConnectedStateOffline);
            Add(_connectedState);
        }

        private void AddUserIcon()
        {
            var userImage = new PoUIImage();
            userImage.Model.Width = "45px";
            userImage.Model.Source = CreateResourceStr(PoIcon_ChatClient.User);
            Add(userImage);
        }

        private void AddUsername()
        {
            var username = new PoUISpan();
            username.Value = FriendName;
            username.Style.SetStyle("width", "150px");
            username.Style.SetStyle("margin", "auto");
            Add(username);
        }
    }
}
