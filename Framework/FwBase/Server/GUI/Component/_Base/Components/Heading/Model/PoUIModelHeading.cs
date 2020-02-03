using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoUIModelHeading : PoUIModel
    {
        public PoUIModelHeading()
        {
            Tag = PoUIHeadingType.H1.ToString().ToLowerInvariant();
        }

        public void SetHeading(PoUIHeadingType headingType)
        {
            Tag = headingType.ToString().ToLowerInvariant();
        }

        public PoUIHeadingType GetHeading()
        {
            foreach (var headingType in (PoUIHeadingType[])Enum.GetValues(typeof(PoUIHeadingType)))
                if (string.Equals(headingType.ToString(), Tag, StringComparison.InvariantCultureIgnoreCase)) return headingType;
            PoLogger.Log(PoLogSource.Default, PoLogType.Error, "Cannot determine heading type using 'Tag'. 'Tag' value: " + Tag);
            return PoUIHeadingType.H1;
        }
    }
}
