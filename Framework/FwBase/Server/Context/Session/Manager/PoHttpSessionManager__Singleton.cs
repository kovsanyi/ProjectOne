using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoHttpSessionManager
    {
        private static readonly Lazy<PoHttpSessionManager> Lazy
            = new Lazy<PoHttpSessionManager>(() => new PoHttpSessionManager());

        public static PoHttpSessionManager Instance => Lazy.Value;
    }
}
