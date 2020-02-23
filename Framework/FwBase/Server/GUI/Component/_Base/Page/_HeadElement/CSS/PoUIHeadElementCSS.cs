using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoUIHeadElementCSS : PoUIHeadElement
    {
        public PoUIHeadElementCSS(string href) : base(href) { }

        public override string ToHTML()
        {
            var ret = $"<link rel=\"stylesheet\" href=\"{Href ?? string.Empty}\">";
            return ret;
        }
    }
}
