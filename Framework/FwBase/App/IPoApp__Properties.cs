using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial interface IPoApp
    {
        public string Name { get; }

        public string Description { get; }

        public string Icon { get; }

        public string AppPrefix { get; }

        public string ToolTipMessage { get; }
    }
}
