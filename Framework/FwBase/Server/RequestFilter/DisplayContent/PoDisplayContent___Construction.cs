using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoDisplayContent
    {
        static PoDisplayContent _instance;
        static readonly object _sync = new object();

        public static PoDisplayContent Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_sync)
                    {
                        if (_instance == null)
                        {
                            _instance = new PoDisplayContent();
                        }
                    }
                }
                return _instance;
            }
        }

        private PoDisplayContent()
        {

        }
    }
}
