using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public abstract partial class PoUIModel : IPoUIModel
    {
        protected string Tag;
        public string ValueBetweenTags;

        public PoUIModel()
        {
            TabIndex = -1;
            Translate = true;
        }
    }
}
