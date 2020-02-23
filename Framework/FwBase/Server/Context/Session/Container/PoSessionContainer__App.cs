using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectOne
{
    partial class PoSessionContainer
    {
        private bool OpenAppPage(string appPrefix, string pageName, out PoUIComponent appContent, out IPoApp appOpened)
        {
            appContent = null;
            appOpened = PoAppManager.AppsMapped.Values.FirstOrDefault(x => x.AppPrefix == appPrefix);
            if (appOpened == null) return false;
            appContent = new PoUIAppForm(appOpened, pageName);
            return true;
        }
    }
}
