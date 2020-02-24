using System;

namespace ProjectOne
{
    public partial class PoAppChatServer : IPoApp
    {
        public void CallOnOpened() { }

        public void CallOnClosed() { }

        public void CallOnStarted()
        {
            //PoChatServer.Instance.Start();
        }

        public void CallOnStopped()
        {
            //PoChatServer.Instance.Stop();
        }
    }
}
