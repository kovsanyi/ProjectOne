using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoRequestFilter
    {

        private static readonly Lazy<PoRequestFilter> Lazy = new Lazy<PoRequestFilter>(() => new PoRequestFilter());

        public static PoRequestFilter Instance => Lazy.Value;

        private PoRequestFilter()
        {
            Filters = new List<IPoRequestFilter>();
            LoadFilters();
        }
    }
}
