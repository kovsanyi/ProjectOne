using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public abstract class PoUIHeadElement
    {
        protected readonly string Href;
        public PoUIHeadElement(string href)
        {
            Href = href;
        }

        public virtual string ToHTML()
        {
            return string.Empty;
        }

        protected bool Equals(PoUIHeadElement other)
        {
            return Href == other.Href;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PoUIHeadElement)obj);
        }

        public override int GetHashCode()
        {
            return (Href != null ? Href.GetHashCode() : 0);
        }
    }
}
