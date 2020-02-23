using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoLogSourceConsole
    {
        private static readonly Lazy<PoLogSourceConsole> Lazy = new Lazy<PoLogSourceConsole>(() => new PoLogSourceConsole());

        public static PoLogSourceConsole Instance => Lazy.Value;

        private PoLogSourceConsole() : base() { }
    }
}
