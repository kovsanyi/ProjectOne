using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public abstract class PoUIHeadElement
    {
        protected string Href;
        public PoUIHeadElement(string href)
        {
            Href = href;
        }

        public virtual string ToHTML()
        {
            return string.Empty;
        }
    }
}
