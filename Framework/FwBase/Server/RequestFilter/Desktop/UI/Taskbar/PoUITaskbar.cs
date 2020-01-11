using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoUITaskbar : PoUILayout
    {
        public PoUITaskbar()
        {
            var icons = createIconsLeft();
            Add(icons);
        }

        PoUIComponent createIconsLeft()
        {
            var a = new PoUIHyperlink();
            var model = (PoUIModelHyperlink)a.Model;
            model.Href = "#start-menu";
            model.Class = "start-menu";
            return a;
        }
    }
}
