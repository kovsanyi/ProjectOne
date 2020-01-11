using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoUIModelHeading : PoUIModel
    {
        public PoUIModelHeading()
        {
            Tag = PoUIHeadingType.H1.ToString();
        }

        public PoUIModelHeading(PoUIHeadingType headingType)
        {
            Tag = headingType.ToString().ToLowerInvariant();
        }
    }
}
