using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public partial class PoUIModel
    {
        public PoUIEvents Events;

        public string Tag;
        public string ValueBetweenTags;

        public PoUIModel()
        {
            TabIndex = -1;
            Translate = true;
            InitEventAttributes();
        }

        public virtual void InitEventAttributes()
        {
            Events = new PoUIEvents();
        }
    }
}
