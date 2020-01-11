using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public partial class PoUIHeading : PoUIComponent
    {
        public PoUIHeading() : this(PoUIHeadingType.H1) { }

        public PoUIHeading(PoUIHeadingType headingType)
        {
            Model = new PoUIModelHeading(headingType);
        }
    }
}
