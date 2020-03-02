using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public /*abstract*/ partial class PoUIModel : IPoUIModel
    {
        public string Tag;
        public string ValueBetweenTags;

        public PoUIModel() : this(string.Empty) { }

        protected PoUIModel(string tag)
        {
            Tag = tag;
            TabIndex = -1;
            Translate = true;
        }
    }
}
