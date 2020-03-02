using System;
using System.Collections.Generic;
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
        }
    }
}
