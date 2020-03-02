using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public abstract partial class PoUIComponent
    {
        public PoUIScript Script;
        public PoUIStyle Style;

        public virtual string ID => string.Empty;

        protected PoUIComponent()
        {
            Script = new PoUIScript();
            Style = new PoUIStyle();
        }

        public virtual List<PoUIHeadElement> HeadElements()
        {
            var headElements = new List<PoUIHeadElement>();
            return headElements;
        }

        public DateTime LastUpdated = DateTime.Now;
        public bool IsDirty;
        public void Refresh()
        {
            IsDirty = true;
            LastUpdated = DateTime.Now;
        }

        private readonly object _sync = new object();
        public bool IsDisposed => _isDisposed;
        private bool _isDisposed = false;

        public void Dispose()
        {
            if (_isDisposed) return;
            lock (_sync)
            {
                if (_isDisposed) return;
                DisposeContent();
            }
        }

        protected virtual void DisposeContent() { }

        public virtual string ToHtml()
        {
            return string.Empty;
        }

        protected string CreateResourceStr(string resource)
        {
            var ret = $"/resource/{resource}";
            return ret;
        }
    }
}
