using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoUIParagraph : PoUIComponent
    {
        public PoUIParagraph()
        {
            Model = new PoUIModel();
            Model.Tag = "p";
        }
    }
}
