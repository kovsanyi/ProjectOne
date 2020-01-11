using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ProjectOne
{
    partial class PoResourceManager
    {
        static PoResourceManager _instance;
        static readonly object _sync = new object();

        public static PoResourceManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_sync)
                    {
                        if (_instance == null)
                        {
                            _instance = new PoResourceManager();
                        }
                    }
                }
                return _instance;
            }
        }

        private PoResourceManager()
        {
            ResourcesMapped = new Dictionary<string, Assembly>();
        }
    }
}
