using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoUIParagraph : PoUIComponent<PoUIModelConfigurable>
    {
        public PoUIParagraph() : base()
        {
            Model.Configure("p");
        }
    }
}
