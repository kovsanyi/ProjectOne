using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoServerRoot
    {
        static PoServerRoot _instance;
        static readonly object _sync = new object();

        public static PoServerRoot Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_sync)
                    {
                        if (_instance == null)
                        {
                            _instance = new PoServerRoot();
                        }
                    }
                }
                return _instance;
            }
        }

        private PoServerRoot()
        {
            setup();
        }
    }
}
