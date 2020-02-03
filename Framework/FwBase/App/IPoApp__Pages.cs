using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial interface IPoApp
    {
        public void CreatePages(PoUIMapPage mapPage);

        public void CreateMenu(PoUIMapMenu mapMenu);

        public void CreateToolbar(PoUIMapToolbar mapToolbar);
    }
}
