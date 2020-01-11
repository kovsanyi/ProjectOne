using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoDisplayContent
    {
        public bool TryOpenAppPage(string appPrefix, out PoUIPage appPage)
        {
            appPage = null;
            return false;
        }

        public bool TryOpenApp(string appPrefix, out PoUIComponent appContent)
        {
            appContent = null;
            return false;
        }
    }
}
