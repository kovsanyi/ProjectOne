using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoUIFriendListItem
    {
        protected override void DisposeContent()
        {
            if (_connectedState != null)
            {
                _connectedState.Dispose();
                _connectedState = null;
            }
            base.DisposeContent();
        }
    }
}
