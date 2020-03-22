using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoChatClientMessageManager
    {
        private static readonly Lazy<PoChatClientMessageManager> Lazy
            = new Lazy<PoChatClientMessageManager>(() => new PoChatClientMessageManager());

        public static PoChatClientMessageManager Instance => Lazy.Value;
    }
}
