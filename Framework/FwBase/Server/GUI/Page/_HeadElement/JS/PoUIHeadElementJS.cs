using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoUIHeadElementJS : PoUIHeadElement
    {
        protected bool Async;
        protected bool Defer;

        public PoUIHeadElementJS(string href, bool async = false, bool defer = false) : base(href)
        {
            Async = async;
            Defer = defer;
        }

        public override string ToHTML()
        {
            var ret = $"<script src=\"{Href ?? ""}\"{(Async ? " async" : "")}{(Defer ? " defer" : "")}></script>";
            return ret;
        }
    }
}
