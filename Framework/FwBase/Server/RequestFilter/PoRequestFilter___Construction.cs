using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoRequestFilter
    {
        static PoRequestFilter _instance;
        static readonly object _sync = new object();

        public static PoRequestFilter Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_sync)
                    {
                        if (_instance == null)
                        {
                            _instance = new PoRequestFilter();
                        }
                    }
                }
                return _instance;
            }
        }

        private PoRequestFilter()
        {
            Filters = new List<IPoRequestFilter>();
            LoadFilters();
        }
    }
}
