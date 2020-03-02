using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoUISpan : PoUIComponent<PoUIModelConfigurable>
    {
        public PoUISpan() : base()
        {
            Model.Configure("span");
        }
    }
}
