using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoChatServerMessageManager
    {
        private static readonly Lazy<PoChatServerMessageManager> Lazy
            = new Lazy<PoChatServerMessageManager>(() => new PoChatServerMessageManager());

        public static PoChatServerMessageManager Instance => Lazy.Value;
    }
}
