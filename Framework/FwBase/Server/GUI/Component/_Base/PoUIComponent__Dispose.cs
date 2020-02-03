using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoUIComponent<T>
    {
        readonly object _sync = new object();
        bool IsDisposed;

        public void Dispose()
        {
            if (IsDisposed) return;
            lock (_sync)
            {
                if (IsDisposed) return;
                DisposeContent();
            }
        }

        protected virtual void DisposeContent()
        {
            if (Model == null) return;
            Model = null;
        }
    }
}
