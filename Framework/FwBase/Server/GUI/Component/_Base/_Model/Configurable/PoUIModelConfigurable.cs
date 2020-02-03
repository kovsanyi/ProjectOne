using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoUIModelConfigurable : PoUIModel
    {
        public PoUIModelConfigurable() : base() { }

        private bool configured;
        public void Configure(string tag)
        {
            if (configured)
            {
                PoLogger.Log(PoLogSource.Default, PoLogType.Warn, $"{nameof(PoUIModelConfigurable)} already configured. Tag=" + Tag);
                return;
            }
            Tag = tag;
            configured = true;
        }
    }
}
