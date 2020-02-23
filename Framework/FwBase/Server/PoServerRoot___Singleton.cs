using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoServerRoot
    {
        private static readonly Lazy<PoServerRoot> Lazy = new Lazy<PoServerRoot>(() => new PoServerRoot());

        public static PoServerRoot Instance => Lazy.Value;

        private PoServerRoot()
        {
            setup();
        }
    }
}
