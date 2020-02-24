using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoChatServer
    {
        private static readonly Lazy<PoChatServer> Lazy
            = new Lazy<PoChatServer>(() => new PoChatServer());

        public static PoChatServer Instance => Lazy.Value;

        private PoChatServer()
        {

        }
    }
}
