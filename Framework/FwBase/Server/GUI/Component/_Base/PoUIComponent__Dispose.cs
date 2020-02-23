using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoUIComponent<T>
    {
        protected override void DisposeContent()
        {
            Model = null;
            base.DisposeContent();
        }
    }
}
