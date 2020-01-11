using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial interface IPoApp
    {
        public void CallOnStarted();

        public void CallOnStopped();

        public void CallOnOpened();

        public void CallOnClosed();
    }
}
