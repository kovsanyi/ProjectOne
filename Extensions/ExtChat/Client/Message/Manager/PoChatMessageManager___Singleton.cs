using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoChatMessageManager
    {
        private static readonly Lazy<PoChatMessageManager> Lazy
            = new Lazy<PoChatMessageManager>(() => new PoChatMessageManager());

        public static PoChatMessageManager Instance => Lazy.Value;
    }
}
