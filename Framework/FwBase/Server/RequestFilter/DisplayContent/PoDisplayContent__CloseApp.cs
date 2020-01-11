using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoDisplayContent
    {
        public bool TryCloseAppPage(string appPrefix, out PoUIPage appPage)
        {
            appPage = null;
            return false;
        }

        public bool TryCloseApp(string appPrefix, out PoUIComponent appContent)
        {
            appContent = null;
            return false;
        }
    }
}
