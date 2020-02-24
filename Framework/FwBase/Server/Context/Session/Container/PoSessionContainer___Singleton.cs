using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoSessionContainer
    {
        private static readonly Lazy<PoSessionContainer> Lazy
            = new Lazy<PoSessionContainer>(() => new PoSessionContainer());

        public static PoSessionContainer Instance => Lazy.Value;

    }
}
