using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjectOne
{
    public partial class PoBootloader
    {
        static PoBootloader _instance;
        static readonly object _sync = new object();

        public static PoBootloader Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_sync)
                    {
                        if (_instance == null)
                        {
                            _instance = new PoBootloader();
                        }
                    }
                }
                return _instance;
            }
        }

        private PoBootloader()
        {

        }
    }
}
