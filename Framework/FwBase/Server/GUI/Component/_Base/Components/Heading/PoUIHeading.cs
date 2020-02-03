using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public partial class PoUIHeading : PoUIComponent<PoUIModelHeading>
    {
        public PoUIHeading() : this(PoUIHeadingType.H1) { }

        public PoUIHeading(PoUIHeadingType headingType) : base()
        {
            Model.SetHeading(headingType);
        }

        public PoUIHeadingType HeadingType
        {
            get => Model.GetHeading();
            set => Model.SetHeading(value);
        }
    }
}
